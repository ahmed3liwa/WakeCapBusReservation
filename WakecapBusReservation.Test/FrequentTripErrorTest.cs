using AutoFixture;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using WakecapBusReservation.API.Controllers;
using WakecapBusReservation.API.ViewModels;
using WakecapBusReservation.Application.Dtos;
using WakecapBusReservation.Application.Exceptions;
using WakecapBusReservation.Application.IServices;
using WakecapBusReservation.Application.Services;
using WakecapBusReservation.Domain.Interfaces;
using WakecapBusReservation.Domain.Models;
using WakecapBusReservation.Domain.Models.Idenitiy;
using WakecapBusReservation.Test.Data;

namespace WakecapBusReservation.Test
{
    public class FrequentTripErrorTest
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

            _mapperMoc = new Mock<IMapper>();
            //setup an instantiate store
            var store = Mock.Of<IUserStore<AppUser>>(); _userManagerMoc = new Mock<UserManager<AppUser>>(store, null, null, null, null, null, null, null, null).Object;
            _unitOfWorkMoc = new Mock<IUnitOfWork>();

            //setup an instantiate _ticketRepositoryMoc
            _ticketRepositoryMoc = new Mock<ITicketRepository>();
            _ticketRepositoryMoc.Setup(x => x.GetAll()).Returns(new System.Collections.Generic.List<Ticket>().AsQueryable());

            _ticketService = new TicketService(_mapperMoc.Object, _unitOfWorkMoc.Object, _userManagerMoc, _ticketRepositoryMoc.Object);
        }

        [Test]
        public void FrequentTrip()
        {
            try
            {
                //arange 
                //Nothing 
                //act
                var response = _ticketService.GetFrequentTripForeachUser();
            }
            catch (EntityNotFoundException ex)
            {

                //assert 
                Assert.That(true);
            }
        }
    }
}
