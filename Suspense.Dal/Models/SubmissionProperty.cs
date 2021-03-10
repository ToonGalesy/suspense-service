using System;

namespace Suspense.Dal.Models
{
    public class SubmissionProperty
    {
        public Guid Id { get; set;  }

        public string Property { get; set;  }

        public string PreviousValue { get; set;  }

        public string NewValue { get; set;  }

        public SubmissionChange SubmissionChange { get; set;  }
    }
}