using System;

namespace TimeTable.Models
{
    public class ClientDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }      
        public string FullName => FirstName + " " + LastName + " " + MiddleName;
    }
}
