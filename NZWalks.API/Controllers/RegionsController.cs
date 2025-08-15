using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegionsController : ControllerBase
	{
		private readonly NZWalksDbContext dbContext;
		private readonly IRegionRepository regionRepository;
		private readonly IMapper mapper;

		public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
		{
			this.dbContext = dbContext;
			this.regionRepository = regionRepository;
			this.mapper = mapper;
		}
		[HttpGet]
		[Authorize(Roles = "Reader" )]
		public async Task<IActionResult> GetAll()
		{

			var regionsDomain = await regionRepository.GetAllAsync();

			return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
		}

		[HttpGet]
		[Route("{id:Guid}")]
		[Authorize(Roles = "Reader")]
		public async Task<IActionResult> GetById(Guid id)
		{

			var regionDomain = await regionRepository.GetByIdAsync(id);

			if (regionDomain == null)
			{
				return NotFound();
			}

			return Ok(mapper.Map<RegionDto>(regionDomain));
		}
		[HttpPost]
		[ValidateModel]
		[Authorize(Roles = "Writer")]
		public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
		{
			
				var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

				regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

				var regionDto = mapper.Map<RegionDto>(regionDomainModel);

				return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDto);
			
		
		}
		[HttpPut]
		[Route("{id:Guid}")]
		[ValidateModel]
		[Authorize(Roles = "Writer")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
		{
			
				var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

				regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

				if (regionDomainModel == null)
				{
					return NotFound();
				}

				return Ok(mapper.Map<RegionDto>(regionDomainModel));
			
		}
		[HttpDelete]
		[Route("{id:Guid}")]
		[Authorize(Roles = "Writer")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			var regionDomainModel = await regionRepository.DeleteAsync(id);

			if (regionDomainModel == null)
			{
				return NotFound();	
			}

			return Ok(mapper.Map<RegionDto>(regionDomainModel));
		}

	}
}
 