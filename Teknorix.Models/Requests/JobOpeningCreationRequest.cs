namespace Teknorix.Models.Requests
{
    public class JobOpeningCreationRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string LocationId { get; set; }
        public string DepartmentId { get; set; }
        public DateTime ClosingDate { get; set; }
    }
}
