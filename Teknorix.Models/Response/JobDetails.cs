using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknorix.Models.Response
{
    public class JobDetails
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public Department Department { get; set; }
        public string PostedDate { get; set; }
        public string ClosingDate { get; set; }
    }

    public class Location
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public long Zip { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
