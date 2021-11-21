using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTable.Models
{
    public class ReservedTime
    {
        public  DateTime ReservetionFrom { get; set; }
        public DateTime ReservationTo { get; set; }
        public Client Client { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsPayed { get; set; }
    }
}
