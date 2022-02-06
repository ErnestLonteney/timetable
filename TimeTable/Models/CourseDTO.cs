using System;

namespace TimeTable.Models
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] PossibleDays { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
