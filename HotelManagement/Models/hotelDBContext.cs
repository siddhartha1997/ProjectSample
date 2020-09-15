using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class hotelDBContext:DbContext
    {
        public hotelDBContext(DbContextOptions options):base(options)
        { }
        public hotelDBContext()
        {

        }
        public  virtual DbSet<Boarder> Boarders { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
    }
}
