using Microsoft.EntityFrameworkCore;
using Suspense.Ddd.Infrastructure.EntityConfigurations;
using Suspense.Ddd.Models;

namespace Suspense.Ddd.Infrastructure
{
    public class SuspenseContext : DbContext
    {
        public SuspenseContext(DbContextOptions<SuspenseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder
            //    .Entity<Submission>()
            //    .Property(e => e.SubmissionStatusId)
            //    .HasConversion<int>();

            //modelBuilder
            //    .Entity<SubmissionStatus>()
            //    .Property(e => e.Id)
            //    .HasConversion<int>();

            //modelBuilder
            //    .Entity<SubmissionStatus>().HasData(
            //        Enum.GetValues(typeof(SubmissionStatusId))
            //            .Cast<SubmissionStatusId>()
            //            .Select(e => new SubmissionStatus()
            //            {
            //                Id = e,
            //                Description = e.ToString()
            //            })
            //    );

            modelBuilder.ApplyConfiguration(new SubmissionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SubmissionPropertyEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SubmissionStatusEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SubmissionChangeEntityTypeConfiguration());
        }

        public DbSet<Submission> Submissions { get; set; }

        public DbSet<SubmissionChange> SubmissionChanges { get; set; }

        public DbSet<SubmissionProperty> SubmissionProperties { get; set; }

        public DbSet<SubmissionStatus> SubmissionStatus { get; set; }
    }
}