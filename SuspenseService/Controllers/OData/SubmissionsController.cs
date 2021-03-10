using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Suspense.Dal.Infrastructure;
using Suspense.Dal.Models;
using System;
using System.Linq;

namespace SuspenseService.Controllers.OData
{
    /// <summary>
    /// Submissions OData query endpoints.
    /// </summary>
    [ApiVersion("1.0")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route("odata/[controller]")]
    public class SubmissionsController : ODataController
    {
        private readonly SuspenseContext _context;

        private readonly ILogger<Controllers.SubmissionsController> _logger;

        /// <summary>
        /// OData query controller.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public SubmissionsController(ILogger<Controllers.SubmissionsController> logger, SuspenseContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// GET a single submission.
        /// </summary>
        /// <param name="key">The GUID identifier of the submission.</param>
        /// <returns>The Submission for the supplied identifier.</returns>
        [EnableQuery]
        [HttpGet()]
        [Route("GetById/{key}")]
        public SingleResult<Submission> Get(Guid key)
        {
            var sub = _context.Submissions.Where(v => v.Id == key);

            return new SingleResult<Submission>(sub);
        }

        /// <summary>
        /// GET all submissions.
        /// </summary>
        /// <returns>A collection of Submissions.</returns>
        [EnableQuery]
        [HttpGet()]
        public IQueryable<Submission> GetAll()
        {
            return _context.Submissions;
        }
    }
}
