using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class NotificationItem
    {
        public NotificationItem(string id, string personId, string name, string message, bool check, DateTime date) 
        {
            Id = id;    
            PersonId = personId;
            Name = name;
            Message = message;
            Check = check;
            Date = date;
        }
        public string Id { get; }
        public string PersonId { get; }
        public string Name { get; }
        public string Message { get; }
        public bool Check { get; }
        public DateTime Date { get; }

    }
}
