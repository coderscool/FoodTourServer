using Application.Abstractions;
using Contracts.Abstractions.Messages;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BackgroundJobs
{
    public class ScheduleNotification<TMessage> : IScheduleNotification<TMessage>
        where TMessage : IMessage
    {
        private readonly IInteractor<TMessage> _interactor;
        public ScheduleNotification(IInteractor<TMessage> interactor)
        {
            _interactor = interactor;
        }
        public async Task AddScheduleNotification(TMessage @event, int time, CancellationToken cancellationToken)
        {
            var jobId = BackgroundJob.Schedule(() => _interactor.InteractAsync(@event, cancellationToken), TimeSpan.FromMinutes(1));
            Console.WriteLine(jobId);
        }
    }
}
