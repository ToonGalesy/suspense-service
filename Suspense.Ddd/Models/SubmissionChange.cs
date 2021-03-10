using System;
using System.Collections.Generic;
using System.Linq;

namespace Suspense.Ddd.Models
{
    public class SubmissionChange
    {
        private SubmissionChange()
        { }

        public SubmissionChange(string operation, string path, Submission submission)
        {
            _submissionProperties = new List<SubmissionProperty>();
            Id = Guid.NewGuid();
            Operation = operation;
            Path = path;
            //SubmissionId = submissionId;
            Submission = submission;
        }

        public Guid Id { get; }

        public string Operation { get; }

        public string Path { get; }

        public Submission Submission { get; }
        //public Guid SubmissionId { get; }

        private List<SubmissionProperty> _submissionProperties;
        public IReadOnlyCollection<SubmissionProperty> SubmissionProperties => _submissionProperties;

        public void AddSubmissionProperties(IEnumerable<SubmissionProperty> properties)
        {
            _submissionProperties = properties.ToList();
        }
    }
}