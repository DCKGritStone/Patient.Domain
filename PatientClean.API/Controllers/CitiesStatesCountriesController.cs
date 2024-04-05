using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient.Application;
using Patient.Domain;
using Patient.Infrastructure;

namespace PatientClean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly PatientDbContext dbContext;

        public CitiesController(PatientDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var citiesDomain= dbContext.Cities.ToList();

          
                var cityDto = new List<CityDto>();
            foreach (var cityDomain in citiesDomain)
            {
                cityDto.Add(new CityDto()
                {
                    Id = cityDomain.Id,
                    CityName = cityDomain.CityName,
                    StateId = cityDomain.StateId
                });

            }
            return Ok(cityDto);
       

        }

        [HttpPost]

        public IActionResult Create([FromBody] AddCityDto addCityDto)
        {
            var cityDomainModel = new City
            { 
                CityName=addCityDto.CityName,
                StateId= addCityDto.StateId
            };
            dbContext.Cities.Add(cityDomainModel);
            dbContext.SaveChanges();

            var city = new CityDto
            {
                Id = cityDomainModel.Id,
                CityName = cityDomainModel.CityName,
                StateId = cityDomainModel.StateId
            };

            return CreatedAtAction(nameof(Get), new {id = cityDomainModel.Id },cityDomainModel);
        }

        [HttpPut]
        [Route("{id=int}")]

        public IActionResult update([FromRoute] int id, UpdateCityDto updateCityDto)
        {
            var city = dbContext.Cities.FirstOrDefault(c => c.Id == id );

            if (city == null)
            {
                return NotFound();
            }
            city.CityName = updateCityDto.CityName;
            city.StateId = updateCityDto.StateId;

            dbContext.SaveChanges();
            return Ok(city);
        }

        [HttpDelete]

        [Route("{id=int}")]

        public IActionResult Delete ([FromRoute] int id)
        {
            var city = dbContext.Cities.FirstOrDefault(c=> c.Id == id);

            if (city == null)
            {
                return NotFound();
            }

            dbContext.Remove(city);
            dbContext.SaveChanges();
            return Ok(city);
        }
    }
}
