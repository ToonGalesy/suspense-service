using MediatR;
using Suspense.Dal.Models;
using System;
using System.Collections.Generic;

namespace SuspenseService.Dto
{
    public class CreateSubmission : IRequest<Submission>
    {
        public string SubmissionType { get; set; }

        public DateTime SubmissionDate { get; set; }

        public Guid SubmissionStatusId { get; set; }

        public IList<CreateSubmissionChange> SubmissionChanges { get; set; }
    }
}
