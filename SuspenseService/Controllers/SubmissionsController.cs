using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Suspense.Dal.Models;
using SuspenseService.Dto;

namespace SuspenseService.Controllers
{
    /// <summary>
    /// Submission write endpoints.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class SubmissionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Submissions controller
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>
        public SubmissionsController(ILogger<SubmissionsController> logger, IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// POST a single Submission.
        /// </summary>
        /// <param name="request">The Submission to add.</param>
        /// <returns>The created Submission.</returns>
        [HttpPost()]
        public async Task<ActionResult<Submission>> Post(CreateSubmission request)
        {
            // Let MediatR dispatch the incoming command
            var submission = await _mediator.Send(request).ConfigureAwait(false);

            return submission;
        }

        /// <summary>
        /// PATCH a single Submission.
        /// </summary>
        /// <param name="request">The Submission to add.</param>
        /// <returns>The created Submission.</returns>
        [HttpPatch()]
        public async Task<ActionResult<Submission>> Patch(UpdateSubmission request)
        {
            // Let MediatR dispatch the incoming command
            var submission = await _mediator.Send(request).ConfigureAwait(false);

            return submission;
        }
    }
}