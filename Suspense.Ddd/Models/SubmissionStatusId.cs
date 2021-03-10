namespace Suspense.Ddd.Models
{
    /// <summary>
    /// The state of a Submission.
    /// </summary>
    public enum SubmissionStatusId
    {
        /// <summary>
        /// The sibmission has been submitted.
        /// </summary>
        Submitted = 1,
        /// <summary>
        /// The Submission is pending review.
        /// </summary>
        PendingReview = 2,
        /// <summary>
        /// The changes have been actioned.
        /// </summary>
        Actioned = 3,
        /// <summary>
        /// The changes have been accepted.
        /// </summary>
        Deleted = 4
    }
}