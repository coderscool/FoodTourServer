using Infrastructure.Hubs.Abstractions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Hubs
{
    public class QueueService : IQueueService
    {
        private static readonly ConcurrentDictionary<string, string> UserConnections = new();

        public void AppendUserConnection(string userId, string connectionId)
        {
            if (!UserConnections.ContainsKey(userId)) { UserConnections[userId] = connectionId; }
        }

        public string GetConnectionId(string userId)
        {
            return UserConnections[userId];
        }

        public ConcurrentDictionary<string, string> GetUserConnection()
        {
            return UserConnections;
        }

        public void RemoveUserConnection(string connectionId)
        {
            //string userId = UserConnections.FirstOrDefault(x => x.Value == connectionId).Key;
            //UserConnections.TryRemove(userId, out connectionId);
            Console.WriteLine(connectionId);
        }
    }
}
