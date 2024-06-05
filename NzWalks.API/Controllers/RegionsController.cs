using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NzWalks.API.Data;
using NzWalks.API.Models.Domain;
using NzWalks.API.Models.DTO;

namespace NzWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _context;

        public RegionsController(NZWalksDbContext context)
        {
            _context = context;
        }

        [HttpGet]   
        public IActionResult GetAll()
        {
            #region FakeData 1
            //var regions = new List<Region>
            //{
            //    new Region
            //    {
            //        Id=Guid.NewGuid(),
            //        Name="Auckland Region",
            //        Code="AKL",
            //        RegionImageUrl="https://images/pexels.com/photos/5169056/pexels-photo-5169056.jpg"
            //    },
            //     new Region
            //    {
            //        Id=Guid.NewGuid(),
            //        Name="Wellington Region",
            //        Code="WLG",
            //        RegionImageUrl="https://images/pexels.com/photos/5169056/pexels-photo-5169056.jpg"
            //    }
            //};
            #endregion  

            // Get Database From Database - Domain models
            var regionsDomain = _context.Regions.ToList();
            // Map Domain Models to DTOs
            var regionDto =new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionDto.Add(new RegionDto() { 
                    Id = regionDomain.Id,
                    Name = regionDomain.Name,
                    Code= regionDomain.Code,
                    RegionImageUrl= regionDomain.RegionImageUrl
                });
            }
            return Ok(regionDto); 
            //Return Dto's
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var region = _context.Regions.FirstOrDefault(x => x.Id == id); 
            //var region = _context.Regions.Find(id);  

            if (region == null)
            {
                return NotFound();
            }
            var regionDto = new RegionDto
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };
           return Ok(region);
        }
        //Post
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto requestDto)
        {
           
            var regionDomainModel = new Region
            {
                Name = requestDto.Name,
                Code = requestDto.Code,
                RegionImageUrl = requestDto.RegionImageUrl
            };
       
            _context.Regions.Add(regionDomainModel);
            _context.SaveChanges();


            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }






    }




}
