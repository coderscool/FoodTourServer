using Application.Abstractions;
using Contracts.Abstractions.Messages;
using Contracts.Services.Restaurant;
using Domain.Entities.Schedule;
using Hangfire;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BackgroundJobs
{
    public class ScheduleNotification : IScheduleNotification
    {
        private readonly IInteractor<DomainEvent.ExpireOrderRestaurant> _interactor;
        private static readonly List<Schedule> ListSchedule = new List<Schedule>();
        public ScheduleNotification(IInteractor<DomainEvent.ExpireOrderRestaurant> interactor)
        {
            _interactor = interactor;
        }
        public async Task AddScheduleNotification(string id, int time, CancellationToken cancellationToken)
        {
            var @event = new DomainEvent.ExpireOrderRestaurant(id, 1);
            Console.WriteLine(@event);
            var jobId = BackgroundJob.Schedule(() => _interactor.InteractAsync(@event, cancellationToken), TimeSpan.FromMinutes(time));
            Console.WriteLine(jobId);
            var job = new Schedule
            {
                Id = id,
                JobId = jobId,
            };
            ListSchedule.Add(job);
        }

        public async Task RemoveSchedule(string id)
        {
            var schedule = ListSchedule.FirstOrDefault(x => x.Id == id);
            if (schedule != null)
            {
                BackgroundJob.Delete(schedule.JobId);
                ListSchedule.Remove(schedule);
            }
        }
    }
}
