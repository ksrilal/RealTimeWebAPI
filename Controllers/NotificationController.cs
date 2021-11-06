using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeWebAPI.Hubs;
using RealTimeWebAPI.Models;
using RealTimeWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _service;
        private readonly IHubContext<NotificationHub, INotificationHub> _hubContext;

        public NotificationController(INotificationService service, IHubContext<NotificationHub, INotificationHub> hubContext)
        {
            _service = service;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Notification>> Get()
        {
            return await _service.Get();
        }

        [HttpGet("{id}")]
        public async Task<Notification> Get(int id)
        {
            return await _service.Get(id);
        }

        [HttpPost]
        public async Task<Notification> Post([FromBody] Notification notification)
        {

            try
            {
                _hubContext.Clients.All.BroadcastMessage(notification);
                return await _service.Create(notification);
            }
            catch (Exception e)
            {
                return notification;
            }
        }

        [HttpPut]
        public async Task Put([FromBody] Notification notification)
        {
            await _service.Update(notification);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
