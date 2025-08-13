using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegionsController : ControllerBase
	{
		private readonly NZWalksDbContext dbContext;
		public RegionsController(NZWalksDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		[HttpGet]
		public IActionResult GetAll()
		{
		
			var regionsDomain = dbContext.Regions.ToList();

			var regionsDto = new List<RegionDto>();

			foreach (var regionDomain in regionsDomain)
			{
				regionsDto.Add(new RegionDto()
				{
					Id = regionDomain.Id,
					Code = regionDomain.Code,
					Name = regionDomain.Name,
					RegionImageUrl = regionDomain.RegionImageUrl,
				});
			}
			 

			return Ok(regionsDto);
		}

		[HttpGet]
		[Route("{id:Guid}")]
		public IActionResult GetById(Guid id)
		{
			//var region = dbContext.Regions.Find(id);

			var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);

			if (regionDomain == null)
			{
				return NotFound();
			}

			var regionDto = new RegionDto
			{
				Id = regionDomain.Id,
				Code = regionDomain.Code,
				Name = regionDomain.Name,
				RegionImageUrl = regionDomain.RegionImageUrl,
			};

			return Ok(regionDto);
		}
	}
}
 