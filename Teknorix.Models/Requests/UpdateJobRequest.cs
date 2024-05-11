using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknorix.Models.Requests
{
    public class UpdateJobRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? LocationId { get; set; }
        public string? DepartmentId { get; set; }
        public DateTime? ClosingDate { get; set; }
    }
}
