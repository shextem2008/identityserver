using DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
	public class Complaint
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
