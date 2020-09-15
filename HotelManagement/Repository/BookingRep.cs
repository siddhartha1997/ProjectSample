using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Repository
{
    public class BookingRep : iBookingRep
    {
        hotelDBContext db;
        public BookingRep(hotelDBContext _db)
        {
            db = _db;
        }
        public int AddDetail(Booking booking)
        {
            db.Bookings.Add(booking);
            db.SaveChanges();
            return booking.BookingId;
        }

        public int Delete(int id)
        {
            int result = 0;
            if (db != null)
            {
                var post = db.Bookings.FirstOrDefault(x => x.BookingId == id);
                if (post != null)
                {
                    db.Bookings.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }
            return result;
        }

        public Booking GetDetail(int id)
        {
            if (db != null)
            {
                return (db.Bookings.Where(x => x.BookingId == id)).FirstOrDefault();
            }
            return null;
        }

        public List<Booking> GetDetails()
        {
            return db.Bookings.ToList(); 
        }

        /*public int UpdateDetail(int id, Booking booking)
        {
            throw new NotImplementedException();
        }*/
    }
}
