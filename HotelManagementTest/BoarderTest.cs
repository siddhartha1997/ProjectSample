using NUnit.Framework;
using System.Collections.Generic;
using HotelManagement.Models;
using System.Linq;
using Moq;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Repository;
using HotelManagement.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementTest
{
    public class BoarderTest
    {
        hotelDBContext db = new hotelDBContext();
        [SetUp]
        public void Setup()
        {
            var Boarder = new List<Boarder>
            {
                new Boarder{ FirstName="S", LastName="B", Email="sb@gmail.com", Password="123" },
                new Boarder{ FirstName="D", LastName="D", Email="dd@gmail.com", Password="123" },
                new Boarder{ FirstName="B", LastName="C", Email="bc@gmail.com", Password="123" }
            };
            var Boarderdata = Boarder.AsQueryable();
            var mockSet = new Mock<DbSet<Boarder>>();
            mockSet.As<IQueryable<Boarder>>().Setup(m => m.Provider).Returns(Boarderdata.Provider);
            mockSet.As<IQueryable<Boarder>>().Setup(m => m.Expression).Returns(Boarderdata.Expression);
            mockSet.As<IQueryable<Boarder>>().Setup(m => m.ElementType).Returns(Boarderdata.ElementType);
            mockSet.As<IQueryable<Boarder>>().Setup(m => m.GetEnumerator()).Returns(Boarderdata.GetEnumerator());
            var mockContext = new Mock<hotelDBContext>();
            mockContext.Setup(c => c.Boarders).Returns(mockSet.Object);
            db = mockContext.Object;
        }
        [Test]
        public void GetBoarder()
        {
            var repo = new Mock<BoarderRep>(db);
            BoarderController controller = new BoarderController(repo.Object);
            var data = controller.Get();
            var result = data as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [Test]
        public void GetByEmailPositive()
        {
            var repo = new Mock<BoarderRep>(db);
            BoarderController controller = new BoarderController(repo.Object);
            var data = controller.Get("sb@gmail.com");
            var result = data as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [Test]

        public void GetByEmailNegative()
        {
            var repo = new Mock<BoarderRep>(db);
            BoarderController controller = new BoarderController(repo.Object);
            var data = controller.Get("sujoy123@gmail.com");
            var result = data as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }
        [Test]
        public void PostBoarder()
        {
            var repo = new Mock<BoarderRep>(db);
            BoarderController controller = new BoarderController(repo.Object);
            Boarder boarder = new Boarder{ FirstName="Sid",LastName="Ban",Email="sban@gmail.com",Password="123" };
            var data = controller.Post(boarder) as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);
        }
        [Test]
        public void PutBoarderPositive()
        {
            var repo = new Mock<BoarderRep>(db);
            BoarderController controller = new BoarderController(repo.Object);
            Boarder boarder = new Boarder{ FirstName="Siddhartha",LastName="Banerjee" };
            var data = controller.Put("sb@gmail.com", boarder) as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);
        }
        [Test]

        public void DeleteBoarderPositive()
        {
            var repo = new Mock<BoarderRep>(db);
            BoarderController controller = new BoarderController(repo.Object);
            var data = controller.Delete("dd@gmail.com") as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);
        }
    }
}