using RealTimeWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeWebAPI.Hubs
{
    public interface INotificationHub
    {
        Task BroadcastMessage(Notification message);
    }
}
