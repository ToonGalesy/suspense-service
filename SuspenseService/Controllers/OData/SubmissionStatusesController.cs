using System;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Suspense.Dal.Infrastructure;
using Suspense.Dal.Models;

namespace SuspenseService.Controllers.OData
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route("odata/[controller]")]
    public class SubmissionStatusesController : ControllerBase
    {
        private readonly SuspenseContext _context;

        private readonly ILogger<Controllers.SubmissionsController> _logger;

        public SubmissionStatusesController(ILogger<Controllers.SubmissionsController> logger, SuspenseContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// GET a single submission status.
        /// </summary>
        /// <param name="id">The identifier of the submission status.</param>
        /// <returns>The Submission for the supplied identifier.</returns>
        [EnableQuery]
        [HttpGet()]
        [Route("GetById/{id}")]
        public SingleResult<SubmissionStatus> Get(Guid id)
        {
            return new SingleResult<SubmissionStatus>(_context.SubmissionStatus.Where(v => v.Id == id));
        }

        /// <summary>
        /// GET all submissions statuses.
        /// </summary>
        /// <returns>A collection of Submissions Statuses.</returns>
        [EnableQuery]
        [HttpGet()]
        public IQueryable<SubmissionStatus> GetAll()
        {
            return _context.SubmissionStatus;
        }
    }
}
