using System;

namespace Suspense.Ddd.Models
{
    public class SubmissionStatus
    {
        private SubmissionStatus()
        { }

        public SubmissionStatus(string description)
        {
            Id = Guid.NewGuid();
            Description = description;
        }

        public Guid Id { get; }

        public string Description { get; }
    }
}