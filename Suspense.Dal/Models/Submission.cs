using System;
using System.Collections.Generic;

namespace Suspense.Dal.Models
{
    public class Submission
    {
        public Submission()
        {
            SubmissionChanges = new List<SubmissionChange>();
        }

        public Guid Id { get; set; }

        public string SubmissionType { get; set; }

        public DateTime SubmissionDate { get; set; }

        public Guid SubmissionStatusId { get; set; }

        public IEnumerable<SubmissionChange> SubmissionChanges { get; set; }
    }
}