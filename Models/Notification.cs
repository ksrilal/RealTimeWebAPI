using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeWebAPI.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public DateTime Time { get; set; }
    }
}
