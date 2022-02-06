using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTable.Data.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }     
        public string MiddleName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        
        [NotMapped]
        public string FullName => FirstName + " " + LastName + " " + MiddleName;
    }
}