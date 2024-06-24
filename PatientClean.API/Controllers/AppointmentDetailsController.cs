using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Patient.Application;
using Patient.Domain;
using Patient.Infrastructure;

namespace PatientClean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentDetailsController : ControllerBase
    {
        private readonly PatientDbContext dbContext;

        public AppointmentDetailsController(PatientDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]

        public IActionResult GetAppointmentDetail()
        {

            var appointmentsDomian= dbContext.AppointmentDetails.ToList();

            var appointmentDto = new List<AppointmentDto>();

            foreach (var appointmentDomain in appointmentsDomian)
            {
                

               
                    appointmentDto.Add(new AppointmentDto
                    {
                        Id = appointmentDomain.Id,
                        TokenNo = appointmentDomain.TokenNo,
                        DoctorName = appointmentDomain.DoctorName,
                        PatientId = appointmentDomain.PatientId
                    });

                
            }return Ok(appointmentDto);
        }

        [HttpPost]
        public IActionResult CreateAppointmentDetails([FromBody] AddAppointmentDto addAppointmentDto)
        {
            var appointmentsDomianModel = new AppointmentDetail
            {
                TokenNo = addAppointmentDto.TokenNo,

                DoctorName = addAppointmentDto.DoctorName,
                PatientId = addAppointmentDto.PatientId,

            };
            dbContext.AppointmentDetails.Add(appointmentsDomianModel);
            dbContext.SaveChanges();

            var appointmentDto = new AppointmentDto
            {
                Id = appointmentsDomianModel.Id,
                TokenNo = appointmentsDomianModel.TokenNo,
                DoctorName = appointmentsDomianModel.DoctorName,
                PatientId = appointmentsDomianModel.PatientId
            };

            return CreatedAtAction(nameof(GetAppointmentDetail),new {id = appointmentsDomianModel.Id}, appointmentsDomianModel);

        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Create([FromRoute] int id , [FromBody] UpdateAppointmentDto updateAppointmentDto)
        {
            var appointmentDomain = dbContext.AppointmentDetails.FirstOrDefault(x => x.Id == id);

            if (appointmentDomain == null)
            {
                return NotFound();
            }
            appointmentDomain.TokenNo = updateAppointmentDto.TokenNo;
            appointmentDomain.DoctorName= updateAppointmentDto.DoctorName;

            appointmentDomain.PatientId = updateAppointmentDto.PatientId;

            dbContext.AppointmentDetails.Add(appointmentDomain);

            dbContext.SaveChanges();
            return Ok(appointmentDomain);

        }

        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult Create([FromRoute] int id)
        {
            var appointmentDomain = dbContext.AppointmentDetails.FirstOrDefault(x => x.Id == id);
            if (appointmentDomain == null)
            {
                return NotFound();
            }
            dbContext.Remove(appointmentDomain);
            dbContext.SaveChanges();
            return Ok(appointmentDomain);

        }
    }
}
