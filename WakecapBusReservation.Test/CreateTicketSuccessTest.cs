using AutoFixture;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using WakecapBusReservation.API.Controllers;
using WakecapBusReservation.API.ViewModels;
using WakecapBusReservation.Application.Dtos;
using WakecapBusReservation.Application.IServices;
using WakecapBusReservation.Application.Services;
using WakecapBusReservation.Domain.Interfaces;
using WakecapBusReservation.Domain.Models;
using WakecapBusReservation.Domain.Models.Idenitiy;
using WakecapBusReservation.Test.Data;

namespace WakecapBusReservation.Test
{
    public class CreateTicketSuccessTest
    {
        private ITicketService _ticketService;
        private Mock<IUnitOfWork> _unitOfWorkMoc;
        private Mock<IMapper> _mapperMoc;
        private Mock<ITicketRepository> _ticketRepositoryMoc;
        private Mock<IGenericRepository<Trip>> _tripRepositoryMoc;
        private Mock<IGenericRepository<Route>> _routeRepositoryMoc;
        private Mock<IGenericRepository<Seat>> _seatsRepositoryMoc;
        private Mock<IGenericRepository<TripSeat>> _tripSeatRepository;
        private UserManager<AppUser> _userManagerMoc;


        [SetUp]
        public void Setup()
        {

            //creating request Dto 
            var createTicketDto = new CreateTicketDto()
            {
                TripRoute = "Cairo-Alexandria",
                UserEmail = "ahmedeliwa15@gmail.com",
                Seats = new System.Collections.Generic.List<string>() { "A1", "A2", "A3" }
            };
            //prepare helper variables 
            var users = new System.Collections.Generic.List<AppUser>();
            var createdTickets = new System.Collections.Generic.List<Ticket>();
            var tripSeats = new System.Collections.Generic.List<TripSeat>();
            //setup an instantiate seats generic repositroy 
            _seatsRepositoryMoc = new Mock<IGenericRepository<Seat>>(MockBehavior.Strict);
            _seatsRepositoryMoc.Setup(r => r.GetAll()).Returns(MockData.Seats().AsQueryable());

            //setup an instantiate Routes generic repositroy 
            _routeRepositoryMoc = new Mock<IGenericRepository<Route>>(MockBehavior.Strict);
            _routeRepositoryMoc.Setup(r => r.GetByIdAsync(createTicketDto.TripRoute))
                .ReturnsAsync(MockData.Routes()
                .FirstOrDefault(s => s.Name == createTicketDto.TripRoute));

            //setup an instantiate Trips generic repositroy 
            _tripRepositoryMoc = new Mock<IGenericRepository<Trip>>(MockBehavior.Strict);
            _tripRepositoryMoc.Setup(t => t.GetAll()).Returns(MockData.Trips().AsQueryable());

            //setup an instantiate TripSeat generic repositroy 
            _tripSeatRepository = new Mock<IGenericRepository<TripSeat>>(MockBehavior.Strict);
            _tripSeatRepository.Setup(x => x.Add(It.IsAny<TripSeat>())).Returns(new TripSeat());

            //setup an instantiate _unitOfWorkMoc
            _unitOfWorkMoc = new Mock<IUnitOfWork>(MockBehavior.Strict);
            _unitOfWorkMoc.Setup(r => r.Repository<Trip>()).Returns(_tripRepositoryMoc.Object);
            _unitOfWorkMoc.Setup(r => r.Repository<Seat>()).Returns(_seatsRepositoryMoc.Object);
            _unitOfWorkMoc.Setup(r => r.Repository<Route>()).Returns(_routeRepositoryMoc.Object);
            _unitOfWorkMoc.Setup(r => r.Repository<TripSeat>()).Returns(_tripSeatRepository.Object);
            _unitOfWorkMoc.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

            //setup an instantiate _ticketRepositoryMoc
            _mapperMoc = new Mock<IMapper>();

            //setup an instantiate _ticketRepositoryMoc
            _ticketRepositoryMoc = new Mock<ITicketRepository>(MockBehavior.Strict);
            _ticketRepositoryMoc.Setup(x => x.Add(It.IsAny<Ticket>())).Returns(new Ticket()
            {
                SeatId = "A1",
                Description = "ticket for route Cairo-Alexandria",
                Price = 100,
                ReservationDate = System.DateTime.Now,
                RouteId = createTicketDto.TripRoute,
                UserEmail = createTicketDto.UserEmail
            }).Callback<Ticket>(t => createdTickets.Add(t));

            //setup an instantiate store
            var store = Mock.Of<IUserStore<AppUser>>();
            //setup an instantiate _userManager
            var _userManager = new Mock<UserManager<AppUser>>(store, null, null, null, null, null, null, null, null);
            _userManager.Object.UserValidators.Add(new UserValidator<AppUser>());
            _userManager.Object.PasswordValidators.Add(new PasswordValidator<AppUser>());

            _userManager.Setup(x => x.DeleteAsync(It.IsAny<AppUser>())).ReturnsAsync(IdentityResult.Success);
            _userManager.Setup(x => x.CreateAsync(It.IsAny<AppUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<AppUser, string>((x, y) => users.Add(x));
            _userManager.Setup(x => x.UpdateAsync(It.IsAny<AppUser>())).ReturnsAsync(IdentityResult.Success);
            _userManager.Setup(x => x.FindByEmailAsync(createTicketDto.UserEmail)).ReturnsAsync(new AppUser()
            {
                Email = "ahmedeliwa15@gmail.com"
            }); ;


            _ticketService = new TicketService(_mapperMoc.Object, _unitOfWorkMoc.Object, _userManager.Object, _ticketRepositoryMoc.Object);
        }

        [Test]
        public async Task CreateTicket()
        {

            //arange 
            var creatticketRequest = new CreateTicketViewModel()
            {
                TripRoute = "Cairo-Alexandria",
                UserEmail = "ahmedeliwa15@gmail.com",
                Seats = new System.Collections.Generic.List<string>() { "A1", "A2", "A3" }
            };

            var creatticketRequestDto = new CreateTicketDto()
            {
                TripRoute = "Cairo-Alexandria",
                UserEmail = "ahmedeliwa15@gmail.com",
                Seats = new System.Collections.Generic.List<string>() { "A1", "A2", "A3" }
            };
            //act

            var response = await _ticketService.CreateTicket(creatticketRequestDto);
            //assert 
            Assert.That(response, Is.Not.Null);
            //assert 
            Assert.That(response.Tickets.Count == creatticketRequest.Seats.Count());
            //assert 
            Assert.That(response.UserEmail, Is.EqualTo(creatticketRequest.UserEmail));

        }
    }
}
