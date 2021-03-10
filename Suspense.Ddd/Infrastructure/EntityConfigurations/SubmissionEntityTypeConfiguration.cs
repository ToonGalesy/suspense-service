using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suspense.Ddd.Models;

namespace Suspense.Ddd.Infrastructure.EntityConfigurations
{
    internal class SubmissionEntityTypeConfiguration : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder.ToTable("Submissions", "dbo");

            builder.HasKey(r => r.Id);

            builder.Property(e => e.SubmissionType);
            builder.Property(e => e.SubmissionDate);

            builder.Property(e => e.SubmissionStatusId);
            builder.HasOne<SubmissionStatus>().WithMany().HasForeignKey(e => e.SubmissionStatusId);
            builder.HasMany(c => c.SubmissionChanges).WithOne(c => c.Submission);
        }
    }
}