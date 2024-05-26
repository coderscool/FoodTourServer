using Contracts.Abstractions.Messages;
using Contracts.Services.Notification;
using Hangfire;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class NotificationRequest
    {
        public string PersonId { get; set; }
        public string Message { get; set; }
        public string JobId { get; set; } // Thêm JobId để quản lý công việc
    }
    public class QueueService : IQueueService
    {
        private static readonly List<NotificationRequest> ScheduledNotifications = new List<NotificationRequest>();

        public async Task ScheduleNotification(string PersonId, string Message, int Time)
        {
            var jobId = BackgroundJob.Schedule(() => SendNotification(Message), TimeSpan.FromMinutes(Time));
            var schedule = new NotificationRequest
            {
                PersonId = PersonId,
                Message = Message,
                JobId = jobId
            };
            ScheduledNotifications.Add(schedule);
            Console.WriteLine(jobId);
        }
        public async Task SendNotification(string message)
        {
            Console.WriteLine(message);
        }
    }
}
