using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suspense.Ddd.Models;

namespace Suspense.Ddd.Infrastructure.EntityConfigurations
{
    public class SubmissionPropertyEntityTypeConfiguration : IEntityTypeConfiguration<SubmissionProperty>
    {
        public void Configure(EntityTypeBuilder<SubmissionProperty> builder)
        {
            builder.ToTable("SubmissionProperties", "dbo");

            builder.HasKey(r => r.Id);

            builder.Property(e => e.PreviousValue);
            builder.Property(e => e.NewValue);
            builder.Property(e => e.Property);
        }
    }
}