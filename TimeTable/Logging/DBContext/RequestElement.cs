using System;

namespace TimeTable.Logging.DBContext
{
    public class RequestElement
    {
        public Guid Id { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string Message { get; set; }
    }
}
