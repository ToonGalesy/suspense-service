using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suspense.Ddd.Models;
using System;

namespace Suspense.Ddd.Infrastructure.EntityConfigurations
{
    public class SubmissionStatusEntityTypeConfiguration : IEntityTypeConfiguration<SubmissionStatus>
    {
        public void Configure(EntityTypeBuilder<SubmissionStatus> builder)
        {
            builder.ToTable("SubmissionStatus", "dbo");

            builder.HasKey(r => r.Id);

            builder.Property(e => e.Description);
        }
    }
}