using System;
using System.Collections.Generic;

namespace TimeTable.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DayOfWeek[] PossibleDays { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public virtual ICollection<Client> Clients  { get; set; }
    }
}
