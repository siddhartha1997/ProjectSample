using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Repository
{
    public interface iBoarderRep
    {
        public List<Boarder> GetDetails();
        public Boarder GetDetail(string id);
        public string AddDetail(Boarder boarder);
        public int UpdateDetail(string id, Boarder boarder);
        public int Delete(string id);
    }
}
