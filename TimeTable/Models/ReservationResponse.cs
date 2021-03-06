using System;

namespace TimeTable.Models
{
    public class ReservationResponse
    {
        public bool IsConfirmed { get; set; }
        public DateTime[] Variants { get; set; }

        public virtual ReservetionRequest ByRequest { get; set; } 
    }
}
