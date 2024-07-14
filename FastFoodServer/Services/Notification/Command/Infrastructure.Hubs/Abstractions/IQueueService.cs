using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Hubs.Abstractions
{
    public interface IQueueService
    {
        ConcurrentDictionary<string, string> GetUserConnection();
        void AppendUserConnection(string userId, string connectionId);
        string GetConnectionId(string userId);
        void RemoveUserConnection(string connectionId);
    }
}
