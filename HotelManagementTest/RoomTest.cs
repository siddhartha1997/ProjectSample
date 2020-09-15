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
    class RoomTest
    {
        hotelDBContext db = new hotelDBContext();
        [SetUp]
        public void Setup()
        {
            var Room = new List<Room>
            {
                new Room{ RoomNo=1,RoomType="AC",Price=1234 },
                new Room{ RoomNo=2,RoomType="NONAC",Price=234 },
                new Room{ RoomNo=3,RoomType="AC",Price=1234 }
            };
            var Roomdata = Room.AsQueryable();
            var mockSet = new Mock<DbSet<Room>>();
            mockSet.As<IQueryable<Room>>().Setup(m => m.Provider).Returns(Roomdata.Provider);
            mockSet.As<IQueryable<Room>>().Setup(m => m.Expression).Returns(Roomdata.Expression);
            mockSet.As<IQueryable<Room>>().Setup(m => m.ElementType).Returns(Roomdata.ElementType);
            mockSet.As<IQueryable<Room>>().Setup(m => m.GetEnumerator()).Returns(Roomdata.GetEnumerator());
            var mockContext = new Mock<hotelDBContext>();
            mockContext.Setup(c => c.Rooms).Returns(mockSet.Object);
            db = mockContext.Object;
        }
        [Test]
        public void GetRoom()
        {
            var repo = new Mock<RoomRep>(db);
            RoomController controller = new RoomController(repo.Object);
            var data = controller.Get();
            var result = data as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [Test]
        public void GetByRoomIdPositive()
        {
            var repo = new Mock<RoomRep>(db);
            RoomController controller = new RoomController(repo.Object);
            var data = controller.Get(1);
            var result = data as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [Test]

        public void GetByRoomNoNegative()
        {
            var repo = new Mock<RoomRep>(db);
            RoomController controller = new RoomController(repo.Object);
            var data = controller.Get(5);
            var result = data as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }
        [Test]
        public void PostRoom()
        {
            var repo = new Mock<RoomRep>(db);
            RoomController controller = new RoomController(repo.Object);
            Room room = new Room { RoomNo=4,RoomType="AC",Price=12340 };
            var data = controller.Post(room) as OkObjectResult;
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
        public void DeleteRoomPositive()
        {
            var repo = new Mock<RoomRep>(db);
            RoomController controller = new RoomController(repo.Object);
            var data = controller.Delete(3) as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);
        }
    }
}
