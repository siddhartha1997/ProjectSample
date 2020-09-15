using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Repository
{
    public interface iRoomRep
    {
        public List<Room> GetDetails();
        public Room GetDetail(int id);
        public int AddDetail(Room room);
       //public int UpdateDetail(int id, Room room);
        public int Delete(int id);
    }
}
