using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.BackgroundJobs
{
    public interface IScheduleNotification
    {
        Task AddScheduleNotification(string id, int time, CancellationToken cancellationToken);
        Task RemoveSchedule(string id);
    }
}
