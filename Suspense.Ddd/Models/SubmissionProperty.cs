using System;

namespace Suspense.Ddd.Models
{
    public class SubmissionProperty
    {
        private SubmissionProperty()
        { }

        public SubmissionProperty(string property, string previousValue, string newValue, SubmissionChange submissionChange)
        {
            Id = Guid.NewGuid();
            Property = property;
            PreviousValue = previousValue;
            NewValue = newValue;
            SubmissionChange = submissionChange;
        }

        public Guid Id { get; }

        public string Property { get; }

        public string PreviousValue { get; }

        public string NewValue { get; }

        public SubmissionChange SubmissionChange { get; }
    }
}