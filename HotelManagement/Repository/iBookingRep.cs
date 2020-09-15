using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Repository
{
    public interface iBookingRep
    {
        public List<Booking> GetDetails();
        public Booking GetDetail(int id);
        public int AddDetail(Booking booking);
        //public int UpdateDetail(int id, Booking booking);
        public int Delete(int id);
    }
}
