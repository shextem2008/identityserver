using DataAccess.Entities.Enums;

namespace API.Models
{
	public class ComplaintsModel
    {
        public int Id { get; set; }
        public string CreationTime { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public ComplaintTypes ComplaintType { get; set; }
        public PriorityLevel PriorityLevel { get; set; }
        public string Message { get; set; }
    }
}
