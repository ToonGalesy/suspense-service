using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suspense.Ddd.Models;
using System;

namespace Suspense.Ddd.Infrastructure.EntityConfigurations
{
    public class SubmissionChangeEntityTypeConfiguration : IEntityTypeConfiguration<SubmissionChange>
    {
        public void Configure(EntityTypeBuilder<SubmissionChange> builder)
        {
            builder.ToTable("SubmissionChanges", "dbo");

            builder.HasKey(r => r.Id);

            builder.Property(e => e.Operation);
            builder.Property(e => e.Path);

            var navigation = builder.Metadata.FindNavigation(nameof(SubmissionChange.SubmissionProperties));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            //builder.HasMany(e => e.SubmissionProperties).WithOne(e => e.SubmissionChange);
        }
    }
}