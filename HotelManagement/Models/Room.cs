using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Room
    {
        [Key]
        public int RoomNo { get; set; }
        public string RoomType { get; set; }
        public int Price { get; set; }
    }
}
