using System.Collections.Generic;

namespace SuspenseService.Dto
{
    public class CreateSubmissionChange
    {
        public string Operation { get; set; }

        public string Path { get; set; }

        public IList<CreateSubmissionProperty> SubmissionProperties { get; set; }
    }
}