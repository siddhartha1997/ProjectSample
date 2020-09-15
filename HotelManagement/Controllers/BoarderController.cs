using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoarderController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        //private readonly hotelDBContext _context;
        iBoarderRep db;
        public BoarderController(iBoarderRep _db)
        {
            db = _db;
            _log4net = log4net.LogManager.GetLogger(typeof(BoarderController));
        }
        // GET: api/<BoarderController>
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
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<BoarderController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Boarder data = new Boarder();
            try
            {
                data = db.GetDetail(id);
                if (data == null)
                {
                    return BadRequest(data);
                }
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest(data);
            }
        }

        // POST api/<BoarderController>
        [HttpPost]
        public IActionResult Post([FromBody] Boarder obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var res = db.AddDetail(obj);
                    if (res != null)
                        return Ok(res);
                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // PUT api/<BoarderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Boarder boarder)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var result = db.UpdateDetail(id, boarder);
                    if (result != 1)
                        return BadRequest(result);
                    return Ok(result);
                }
                catch(Exception ex)
                {
                    if(ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        /*private bool BoardersExists(string id)
        {
            throw new NotImplementedException();
        }*/

        // DELETE api/<BoarderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var result = db.Delete(id);
                if (result == 0)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(id);
            }
        }
    }
}
