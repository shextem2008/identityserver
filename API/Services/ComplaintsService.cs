using API.Models;
using API.Utility;
using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
	public interface IComplaintsService
	{
		Task<List<ComplaintsModel>> List();
        Task<bool> AddTravelAsync(ComplaintsModel model);
        Task<bool> Update(int id, ComplaintsModel model);
        Task<ComplaintsModel> GetAsync(int id);
    }

    public class ComplaintsService : IComplaintsService
    {
        private readonly ApplicationDbContext dbContext;

        public ComplaintsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<ComplaintsModel>> List()
        {
            var Complaintss = await (from sh in dbContext.Complaints
                                     select new ComplaintsModel()
                                     {
                                         Id = sh.Id,
                                         Fullname = sh.Fullname,
                                         Email = sh.Email,
                                         CreationTime = sh.CreationTime,
                                         ComplaintType = sh.ComplaintType,
                                         PriorityLevel = sh.PriorityLevel
                                     }).ToListAsync();

            return Complaintss;
        }

        public async Task<ComplaintsModel> GetAsync(int id)
        {
            var FindComplaints = await dbContext.Complaints.FirstOrDefaultAsync(x => x.Id == id);
            var  fCpl = new ComplaintsModel 
            {
                Id = FindComplaints.Id,
                Fullname = FindComplaints.Fullname,
                Email = FindComplaints.Email,
                ComplaintType = FindComplaints.ComplaintType,
                PriorityLevel = FindComplaints.PriorityLevel
            };
           
            return fCpl;
        }

        public async Task<bool> Update(int id, ComplaintsModel model)
        {
            var FindComplaints = await dbContext.Complaints.FirstOrDefaultAsync(x => x.Id == id);

            FindComplaints.Fullname = model.Fullname;
            FindComplaints.Email = model.Email;
            FindComplaints.ComplaintType = model.ComplaintType;
            FindComplaints.PriorityLevel = model.PriorityLevel;

            dbContext.Complaints.Update(FindComplaints);
            await dbContext.SaveChangesAsync();

            return true;
        }


        public async Task<bool> AddTravelAsync(ComplaintsModel model)
        {
            var fCpl = new Complaint()
            {
                Id = model.Id,
                Fullname = model.Fullname,
                Email = model.Email,
                ComplaintType = model.ComplaintType,
                PriorityLevel = model.PriorityLevel
            };

            await dbContext.Complaints.AddAsync(fCpl);
            var suc = await dbContext.SaveChangesAsync();
            if (suc != 1)
            {
                return true;
            }
            throw new MyAppException("something went wrong");
        }

    }

}
