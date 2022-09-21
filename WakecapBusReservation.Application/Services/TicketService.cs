using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakecapBusReservation.Application.Dtos;
using WakecapBusReservation.Application.Exceptions;
using WakecapBusReservation.Application.IServices;
using WakecapBusReservation.Domain.Interfaces;
using WakecapBusReservation.Domain.Models;
using WakecapBusReservation.Domain.Models.Idenitiy;

namespace WakecapBusReservation.Application.Services
{
    public class TicketService : ITicketService
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITicketRepository _ticketRepository;
        private readonly UserManager<AppUser> _userManager;//TODO: should be wrapped in account service.
        #endregion

        #region CTOR
        public TicketService(IMapper mapper, IUnitOfWork unitOfWork,
            UserManager<AppUser> userManager, ITicketRepository ticketRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _ticketRepository = ticketRepository;
            _userManager = userManager;
        }

        #endregion

        #region Methods
        public async Task<CreateTicketSuccessResponseDto> CreateTicket(CreateTicketDto createTicketDto)
        {
            //validate user existance 
            var user = await _userManager.FindByEmailAsync(createTicketDto.UserEmail)
                ?? throw new EntityNotFoundException("AppUser", createTicketDto.UserEmail);
            //validate route existance 
            var triproute = await _unitOfWork.Repository<Route>().GetByIdAsync(createTicketDto.TripRoute)
                ?? throw new EntityNotFoundException("Route", createTicketDto.TripRoute);
            //validate seats 
            var seats = _unitOfWork.Repository<Seat>().GetAll();
            //compare 
            var seatsDiff = createTicketDto.Seats.Where(s => !seats.Any(dbs => dbs.Name == s)).ToList();
            //validate seats diff 
            if (seatsDiff?.Count > 0)
                throw new SeatsNotFoundException(seatsDiff);
            //loading and validating trip assuming trip date is current day date
            var availableTrip = _unitOfWork.Repository<Trip>().GetAll()
                .Where(t => t.Date.Date == DateTime.Now.Date)
                .Include(t => t.Bus)
                .Include(t => t.Tickets)
                .Include(t => t.TripSeats).FirstOrDefault(t => t.TripSeats.Count < t.Bus.Capacity) ?? throw new TripNotFoundException();
            //validate capacity 
            if (createTicketDto.Seats.Count + availableTrip.TripSeats.Count >= availableTrip.Bus.Capacity)
                throw new NoCapacityException();
            //get seats reserved and sent in request
            var reservedSeat = availableTrip.TripSeats.Where(s => createTicketDto.Seats.Any(rs => s.SeatId == rs)).ToList();
            //validate reserved seats 
            if (reservedSeat?.Count > 0)
                throw new SeatsAlreadyReservedException(reservedSeat.Select(s => s.SeatId).ToList());
            //init cuurent request created tickets 
            var createdTickets = new List<Ticket>();
            //adding tickets foreach seat 
            foreach (var seat in createTicketDto.Seats)
            {
                //adding to db set 
                var ticket = _ticketRepository.Add(new Ticket()
                {
                    Description = $"ticket for route {createTicketDto.TripRoute}",
                    Price = availableTrip.Price,
                    SeatId = seat,
                    Trip = availableTrip,
                    ReservationDate = DateTime.Now,
                    UserEmail = createTicketDto.UserEmail,
                    RouteId = createTicketDto.TripRoute
                });
                //adding trip seats 
                var tripseat = _unitOfWork.Repository<TripSeat>().Add(new TripSeat()
                {
                    SeatId = seat,
                    Trip = availableTrip
                });
                //addig to created list 
                createdTickets.Add(ticket);
                await _unitOfWork.SaveChangesAsync();
            }
            //commit to db
            //construct new create ticket success response
            return new CreateTicketSuccessResponseDto()
            {
                UserEmail = createTicketDto.UserEmail,
                BusId = availableTrip.BusId,
                Price = createdTickets.Sum(t => t.Price),
                Tickets = createdTickets.Select(t => new CreateTicketSuccessDto() { SeatId = t.SeatId, TicketId = t.Id }).ToList()
            };
        }

        public List<UserFrequentTripDto> GetFrequentTripForeachUser()
        {
            //preparing results list 
            var userFrequentrouteLst = new List<UserFrequentTripDto>();
            //grouping by user email
            var userGroups = _ticketRepository.GetAll().ToList().GroupBy(t => t.UserEmail).ToList();
            //looping each group 
            foreach (var userGroup in userGroups)
            {
                //using linq groub by and ordeere by to get the most reserved route fro user 
                var mostreservedRote = userGroup.GroupBy(g => g.RouteId)
                    .GroupBy(g => g.Count())
                    .OrderByDescending(g => g.Key)
                    .Take(1)
                    .SelectMany(g => g.Select(g => g.Key))
                    .First();
                //add to result list 
                userFrequentrouteLst.Add(new UserFrequentTripDto()
                {
                    Email = userGroup.Key,
                    FrequentBook = mostreservedRote.ToString()
                });
            }

            //return 
            return userFrequentrouteLst.Count > 0 ? userFrequentrouteLst : throw new EntityNotFoundException("ticket", "");
        }
        #endregion
    }
}
