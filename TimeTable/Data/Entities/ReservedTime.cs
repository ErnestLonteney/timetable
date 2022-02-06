using System;

namespace TimeTable.Data.Entities
{
    public class ReservedTime
    {
        public Guid Id { get; set; }
        public DateTime ReservetionFrom { get; set; }
        public DateTime ReservationTo { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsPaid { get; set; }
        public virtual Client Client { get; set; }
        public virtual Course Course { get; set; }
    }
}
