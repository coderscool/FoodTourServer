using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Abstractions.EventStore;
using Infrastructure.EventStore.Contexts.Converters;

namespace Infrastructure.EventStore.Contexts.Configuratons
{
    public class SnapshotConfiguration : IEntityTypeConfiguration<Snapshot>
    {
        public void Configure(EntityTypeBuilder<Snapshot> builder)
        {
            builder.HasKey(snapshot => snapshot.Timestamp);

            builder
                .Property(snapshot => snapshot.Version)
                .IsRequired();

            builder
                .Property(snapshot => snapshot.AggregateId)
                .IsRequired();

            builder
                .Property(snapshot => snapshot.AggregateType)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(snapshot => snapshot.Timestamp)
                .IsRequired();

            builder
                .Property(snapshot => snapshot.Aggregate)
                .HasConversion<AggregateConverter>()
                .IsRequired();
        }
    }
}
