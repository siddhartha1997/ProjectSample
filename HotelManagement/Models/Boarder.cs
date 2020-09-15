using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Boarder
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }

        internal Boarder Find(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public static object AsQueryable()
        {
            throw new NotImplementedException();
        }
    }
}
