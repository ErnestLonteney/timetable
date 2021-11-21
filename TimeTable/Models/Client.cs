using System;

namespace TimeTable.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string SName { get; set; }
        public string FullName { get; set; }

    }
}