using System;

namespace TimeTable.Logging.DBContext
{
    public class LogElement
    {
        public string CategoryName { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string AdditionalMessage { get; set; }

        public virtual RequestElement Request { get; set; }
    }
}
