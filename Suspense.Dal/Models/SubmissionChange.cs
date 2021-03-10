using System;
using System.Collections.Generic;

namespace Suspense.Dal.Models
{
    public class SubmissionChange
    {
        public SubmissionChange()
        {
            SubmissionProperties = new List<SubmissionProperty>();
        }

        public Guid Id { get; set; }

        public string Operation { get; set; }

        public string Path { get; set; }

        public Submission Submission { get; set; }

        public IEnumerable<SubmissionProperty> SubmissionProperties { get; set; }
    }
}