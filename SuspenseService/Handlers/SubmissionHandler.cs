using MediatR;
using Microsoft.EntityFrameworkCore;
using Suspense.Dal.Infrastructure;
using Suspense.Dal.Models;
using SuspenseService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuspenseService.Handlers
{
    public class SubmissionHandler : IRequestHandler<CreateSubmission, Submission>, IRequestHandler<UpdateSubmission, Submission>
    {
        private readonly SuspenseContext _ctx;

        public SubmissionHandler(SuspenseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Submission> Handle(CreateSubmission request, CancellationToken cancellationToken)
        {
            var submission = new Submission
            {
                Id = Guid.NewGuid(),
                SubmissionDate = DateTime.UtcNow,
                SubmissionType = request.SubmissionType,
                SubmissionStatusId = request.SubmissionStatusId
            };

            var changes = new List<SubmissionChange>();

            foreach (var requestChange in request.SubmissionChanges)
            {
                var change = new SubmissionChange
                {
                        Id = Guid.NewGuid(),
                        Operation = requestChange.Operation,
                        Path = requestChange.Path
                };

                var properties = new List<SubmissionProperty>();

                foreach(var requestProperty in requestChange.SubmissionProperties)
                {
                    var property = new SubmissionProperty
                    {
                        Id = Guid.NewGuid(),
                        PreviousValue = requestProperty.PreviousValue,
                        NewValue = requestProperty.NewValue,
                        Property = requestProperty.Property
                    };

                    properties.Add(property);
                }

                change.SubmissionProperties = properties;

                changes.Add(change);
            }

            submission.SubmissionChanges = changes;

            _ctx.Submissions.Add(submission);

            await _ctx.SaveChangesAsync().ConfigureAwait(false);

            return submission;
        }

        public async Task<Submission> Handle(UpdateSubmission request, CancellationToken cancellationToken)
        {
            var submission = _ctx.Submissions.First(x => x.Id == request.Id);

            if (submission == null)
                throw new InvalidOperationException();

            //submission.UpdateSubmissionStatus(request.SubmissionStatusId);

            _ctx.Attach(submission).State = EntityState.Modified;

            await _ctx.SaveChangesAsync().ConfigureAwait(false);

            return submission;
        }
    }
}