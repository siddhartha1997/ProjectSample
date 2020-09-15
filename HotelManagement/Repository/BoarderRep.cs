using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Repository
{
    public class BoarderRep : iBoarderRep
    {
        hotelDBContext db;
        public BoarderRep(hotelDBContext _db)
        {
            db = _db;
        }
        public string AddDetail(Boarder boarder)
        {
            db.Boarders.Add(boarder);
            db.SaveChanges();
            return boarder.Email;
        }

        public int Delete(string id)
        {
            int result = 0;
            if(db!=null)
            {
                var post = db.Boarders.FirstOrDefault(x => x.Email == id);
                if(post !=null)
                {
                    db.Boarders.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }
            return result;
        }

        public Boarder GetDetail(string id)
        {
            if(db!=null)
            {
                return (db.Boarders.Where(x => x.Email == id)).FirstOrDefault();
            }
            return null;
        }

        public List<Boarder> GetDetails()
        {
            return db.Boarders.ToList();
        }

        public int UpdateDetail(string id, Boarder boarder)
        {
            if (db != null)
            {
                var obj = (db.Boarders.Where(x => x.Email == id)).FirstOrDefault();
                if (obj != null)
                {
                    obj.FirstName = boarder.FirstName;
                    obj.LastName = boarder.LastName;
                    //obj.Email = boarder.Email;
                    obj.Password = boarder.Password;
                    db.SaveChanges();
                    return 1;
                }
            }
            return 0;
        }
    }
}
