using HotelManagement.Controllers;
using HotelManagement.Models;
using HotelManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagementTest
{
    class BookingTest
    {
        hotelDBContext db = new hotelDBContext();
        [SetUp]
        public void Setup()
        {
            var Booking = new List<Booking>
            {
                new Booking{ BookingId=1,Email="sb@gmail.com",RoomNo=1 },
                new Booking{ BookingId=2,Email="dd@gmail.com",RoomNo=2 },
                new Booking{ BookingId=3,Email="bc@gmail.com",RoomNo=3 }
            };
            var Bookingdata = Booking.AsQueryable();
            var mockSet = new Mock<DbSet<Booking>>();
            mockSet.As<IQueryable<Booking>>().Setup(m => m.Provider).Returns(Bookingdata.Provider);
            mockSet.As<IQueryable<Booking>>().Setup(m => m.Expression).Returns(Bookingdata.Expression);
            mockSet.As<IQueryable<Booking>>().Setup(m => m.ElementType).Returns(Bookingdata.ElementType);
            mockSet.As<IQueryable<Booking>>().Setup(m => m.GetEnumerator()).Returns(Bookingdata.GetEnumerator());
            var mockContext = new Mock<hotelDBContext>();
            mockContext.Setup(c => c.Bookings).Returns(mockSet.Object);
            db = mockContext.Object;
        }
        [Test]
        public void GetRoom()
        {
            var repo = new Mock<BookingRep>(db);
            BookingController controller = new BookingController(repo.Object);
            var data = controller.Get();
            var result = data as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [Test]
        public void GetByBookingIdPositive()
        {
            var repo = new Mock<BookingRep>(db);
            BookingController controller = new BookingController(repo.Object);
            var data = controller.Get(1);
            var result = data as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [Test]
        public void GetByBookingIdNegative()
        {
            var repo = new Mock<BookingRep>(db);
            BookingController controller = new BookingController(repo.Object);
            var data = controller.Get(5);
            var result = data as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }
        [Test]
        public void PostRoom()
        {
            var repo = new Mock<BookingRep>(db);
            BookingController controller = new BookingController(repo.Object);
            Booking booking = new Booking { BookingId=4,Email="ac@gmail.com",RoomNo=4 };
            var data = controller.Post(booking) as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);
        }
        /*[Test]
        public void PutBoarderPositive()
        {
            var repo = new Mock<BoarderRep>(db);
            BoarderController controller = new BoarderController(repo.Object);
            Boarder boarder = new Boarder { FirstName = "Siddhartha", LastName = "Banerjee" };
            var data = controller.Put("sb@gmail.com", boarder) as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);
        }*/
        [Test]
        public void DeleteBookingPositive()
        {
            var repo = new Mock<BookingRep>(db);
            BookingController controller = new BookingController(repo.Object);
            var data = controller.Delete(3) as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);
        }
    }
}
