using Dapper;
using Microsoft.Extensions.Configuration;
using RealTimeWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeWebAPI.Services
{
    public class NotificationService : INotificationService
    {
        private readonly string _conectionString;

        public NotificationService(IConfiguration configuration)
        {
            _conectionString = configuration.GetConnectionString("Default");
        }

        public async Task<Notification> Create(Notification notification)
        {
            var query = "INSERT INTO Notifications(Message, Sender, Reciever, Time) VALUES (@Message, @Sender, @Reciever, @Time)";

            using(var connection = new SqlConnection(_conectionString))
            {
                await connection.ExecuteAsync(query, new { notification.Message, notification.Sender, notification.Reciever, notification.Time });
            }

            return notification;
        }

        public async Task Delete(int id)
        {
            var query = "DELETE FROM Notifications WHERE Id = @id";

            using (var connection = new SqlConnection(_conectionString))
            {
                await connection.ExecuteAsync(query, new { id = id });
            }
        }

        public async Task<IEnumerable<Notification>> Get()
        {
            var query = "SELECT * FROM Notifications";

            using(var connection = new SqlConnection(_conectionString))
            {
                return await connection.QueryAsync<Notification>(query);
            }
        }

        public async Task<Notification> Get(int id)
        {
            var query = "SELECT * FROM Notifications WHERE Id = @id";

            using(var connection =  new SqlConnection(_conectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Notification>(query, new { id = id });
            }
        }

        public async Task Update(Notification notification)
        {
            var query = "UPDATE Notifications SET Message = @Message, Sender = @Sender, Reciever = @Reciever, Time = @Time WHERE Id = @Id";

            using(var connection = new SqlConnection(_conectionString))
            {
                await connection.ExecuteAsync(query, new
                {
                    Id = notification.Id,
                    Message = notification.Message,
                    Sender = notification.Sender,
                    Reciever = notification.Reciever,
                    Time = notification.Time
                });
            }
        }
    }
}
