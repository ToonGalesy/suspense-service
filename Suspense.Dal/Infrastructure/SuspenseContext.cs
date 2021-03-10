using Microsoft.EntityFrameworkCore;
using Suspense.Dal.Models;

namespace Suspense.Dal.Infrastructure
{
    public class SuspenseContext : DbContext
    {
        public SuspenseContext(DbContextOptions<SuspenseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Submission> Submissions { get; set; }

        public DbSet<SubmissionChange> SubmissionChanges { get; set; }

        public DbSet<SubmissionProperty> SubmissionProperties { get; set; }

        public DbSet<SubmissionStatus> SubmissionStatus { get; set; }
    }
}