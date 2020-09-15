using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Repository
{
    public class RoomRep : iRoomRep
    {
        hotelDBContext db;
        public RoomRep(hotelDBContext _db)
        {
            db = _db;
        }
        public int AddDetail(Room room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();
            return room.RoomNo;
        }

        public int Delete(int id)
        {
            int result = 0;
            if (db != null)
            {
                var post = db.Rooms.FirstOrDefault(x => x.RoomNo == id);
                if (post != null)
                {
                    db.Rooms.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }
            return result;
        }

        public Room GetDetail(int id)
        {
            if (db != null)
            {
                return (db.Rooms.Where(x => x.RoomNo == id)).FirstOrDefault();
            }
            return null;
        }

        public List<Room> GetDetails()
        {
            return db.Rooms.ToList();
        }

        /*public int UpdateDetail(int id, Room room)
        {
            throw new NotImplementedException();
        }*/
    }
}
