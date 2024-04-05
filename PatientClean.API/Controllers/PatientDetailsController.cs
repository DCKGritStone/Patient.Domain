using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient.Application;
using Patient.Domain;
using Patient.Infrastructure;

namespace PatientClean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDetailsController : ControllerBase
    {
        private readonly PatientDbContext dbContext;

        public PatientDetailsController(PatientDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // For Patient details
        [HttpGet]

        public IActionResult GetPatientDetails()
        {
            var patientsDomain = dbContext.PatientDetails.ToList();

            var patientDto = new List<PatientDto>();
            foreach (var patientDomain in patientsDomain)
            {
              
                    patientDto.Add(new PatientDto()
                    {
                        Id = patientDomain.Id,
                        FirstName = patientDomain.FirstName,
                        LastName = patientDomain.LastName,
                        DOB = patientDomain.DOB,
                        Gender = patientDomain.Gender,
                        Address = patientDomain.Address,
                        CityId = patientDomain.CityId
                    });
                


            } return Ok(patientDto);
        }
        [HttpPost]
        public IActionResult Create([FromBody] AddPatientDetailDto addPatientDetailDto)
        {
            var patientDomainModel = new PatientDetail
            {
                FirstName = addPatientDetailDto.FirstName,
                LastName = addPatientDetailDto.LastName,
                DOB = addPatientDetailDto.DOB,
                Gender = addPatientDetailDto.Gender,
                Address = addPatientDetailDto.Address,
                CityId = addPatientDetailDto.CityId
            };

            dbContext.PatientDetails.Add(patientDomainModel);

            dbContext.SaveChanges();

            var patientDto = new PatientDto
            {
                Id = patientDomainModel.Id,
                FirstName = patientDomainModel.FirstName,
                LastName = patientDomainModel.LastName,
                DOB = patientDomainModel.DOB,
                Gender = patientDomainModel.Gender,
                Address = patientDomainModel.Address,
                CityId = patientDomainModel.CityId
            };

            return CreatedAtAction(nameof(GetPatientDetails), new { id = patientDomainModel.Id }, patientDomainModel);
        }

        [HttpPut]
        [Route("{id:int}")]

        public IActionResult Update([FromRoute] int id , UpdatePatientDto updatePatientDto)
        {
            var patientDomain = dbContext.PatientDetails.FirstOrDefault(p => p.Id == id);

            if (patientDomain == null)
            {
                return NotFound();
            }

            patientDomain.FirstName = updatePatientDto.FirstName;
            patientDomain.LastName = updatePatientDto.LastName;
            patientDomain.DOB = updatePatientDto.DOB;
            patientDomain.Gender = updatePatientDto.Gender;
            patientDomain.Address = updatePatientDto.Address;
            patientDomain.CityId = updatePatientDto.CityId;

            dbContext.SaveChanges();
            return Ok (patientDomain);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult Delete([FromRoute] int id)
        {

            var patientDomain = dbContext.PatientDetails.FirstOrDefault(p => p.Id == id);

            if (patientDomain == null)
            {
                return NotFound();
            }

            dbContext.Remove(patientDomain);
            return Ok(patientDomain);
        }


    }
}
