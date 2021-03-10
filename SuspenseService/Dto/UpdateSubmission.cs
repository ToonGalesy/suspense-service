using MediatR;
using Suspense.Dal.Models;
using System;

namespace SuspenseService.Dto
{
    public class UpdateSubmission : IRequest<Submission>
    {
        public Guid Id { get; set; }

        public Guid SubmissionStatusId { get; set; }
    }
}