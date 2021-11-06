using RealTimeWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeWebAPI.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> Get();
        Task<Notification> Get(int id);
        Task<Notification> Create(Notification notification);
        Task Update(Notification notification);
        Task Delete(int id);
    }
}
