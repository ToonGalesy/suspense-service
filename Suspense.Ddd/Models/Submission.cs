using System;
using System.Collections.Generic;
using System.Linq;

namespace Suspense.Ddd.Models
{
    public class Submission
    {
        private Submission() { }

        public Submission(string submissionType, Guid submissionStatusId)
        {
            if (string.IsNullOrWhiteSpace(submissionType))
                throw new ArgumentNullException(nameof(submissionType));

            if (submissionStatusId == Guid.Empty)
                throw new ArgumentNullException(nameof(submissionStatusId));

            _submissionChanges = new List<SubmissionChange>();
            Id = Guid.NewGuid();
            SubmissionType = submissionType;
            SubmissionDate = DateTime.UtcNow;
            _submissionStatusId = submissionStatusId;
        }

        public Guid Id { get; private set; }

        public string SubmissionType { get; private set; }

        public DateTime SubmissionDate { get; }

        private Guid _submissionStatusId;
        public Guid SubmissionStatusId => _submissionStatusId;

        private List<SubmissionChange> _submissionChanges;
        public IReadOnlyCollection<SubmissionChange> SubmissionChanges => _submissionChanges;

        public void UpdateSubmissionStatus(Guid statusId)
        {
            _submissionStatusId = statusId;
        }

        public void AddSubmissionChanges(IEnumerable<SubmissionChange> changes)
        {
            _submissionChanges = changes.ToList();
        }
    }
}