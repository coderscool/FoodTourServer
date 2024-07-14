using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Hubs.Abstractions
{
    public interface INotificationHub
    {
        Task SendNotificationToUser(string userId, string message);
    }
}
