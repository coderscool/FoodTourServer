using Domain.Abstractions.EventStore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventStore.Contexts
{
    public class EventStoreDbContext : DbContext
    {
        public EventStoreDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<StoreEvent>? Events { get; set; }
        public DbSet<Snapshot>? Snapshots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventStoreDbContext).Assembly);

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        => configurationBuilder
            .Properties<string>()
            .AreUnicode(false)
            .HaveMaxLength(1024);
    }
}
