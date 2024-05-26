using Contracts.Services.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IQueueService
    {
        Task ScheduleNotification(string PersonId, string Message, int Time);
    }
}
