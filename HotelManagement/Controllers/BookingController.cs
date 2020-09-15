using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        //public readonly hotelDBContext _context;
        iBookingRep db;
        public BookingController(iBookingRep _db)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(BookingController));
            //_context = context;
            db = _db;
        }
        // GET: api/<BookingController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var obj = db.GetDetails();
                if (obj == null)
                    return NotFound();
                return Ok(obj);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Booking data = new Booking();
            try 
            {
                data = db.GetDetail(id);
                if (data == null)
                {
                    return BadRequest(data);
                }
                return Ok(data);
            }
            catch(Exception)
            {
                return BadRequest(data);
            }
        }

        // POST api/<BookingController>
        [HttpPost]
        public IActionResult Post([FromBody] Booking obj)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var res = db.AddDetail(obj);
                    if (res != 0)
                        return Ok(res);
                    return NotFound();
                }
                catch(Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // PUT api/<BookingController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = db.Delete(id);
                if(result==0)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch(Exception)
            {
                return BadRequest(id);
            }
        }
    }
}
