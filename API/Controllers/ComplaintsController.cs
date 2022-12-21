using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ComplaintsController : ControllerBase
	{
        private readonly IComplaintsService complaintsService;

		public ComplaintsController(IComplaintsService complaintsService)
		{
			this.complaintsService = complaintsService;
		}

		[HttpGet]
        [Route("Getallcomplain")]
        public async Task<IActionResult> List()
		{
			var complaints = await complaintsService.List();
			return Ok(complaints);
		}


        [HttpGet]
        [Route("GetComplain/{Id}")]
        public async Task<ActionResult> GetComplainById(int Id)
        {
            var traveller = await complaintsService.GetAsync(Id);
            return Ok(traveller);
        }


        [HttpPost]
        [Route("{AddComplain}")]
        public async Task<ActionResult> AddComplain(ComplaintsModel model)
        {
            var travellers = await complaintsService.AddTravelAsync(model);
            return Ok(travellers);
        }

        [HttpPut]
        [Route("UpdateComplain/{Id}")]
        public async Task<ActionResult> UpdateRequest(int Id, ComplaintsModel model)
        {
            return Ok(await complaintsService.Update(Id, model));
        }
    }
}
