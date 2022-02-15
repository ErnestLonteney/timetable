using System;

namespace TimeTable.Models
{
    public class ReservetionRequest
    {
        public Guid Id { get; set; }
        public DateTime ReservetionFrom { get; set; }
        public DateTime ReservationTo { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsPaid { get; set; }
        public Guid ClientId { get; set; }
        public int CourseId { get; set; }
    }
}
