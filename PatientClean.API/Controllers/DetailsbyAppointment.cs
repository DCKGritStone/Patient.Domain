using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Patient.Application;
using Patient.Infrastructure;
using static System.Net.Mime.MediaTypeNames;

namespace PatientClean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsbyAppointment : ControllerBase
    {
        private readonly PatientDbContext dbContext;

        public DetailsbyAppointment(PatientDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        [HttpGet]

        public IActionResult Get()
        {
            var appointmentList = dbContext.AppointmentDetails.ToList();
            var patientList = dbContext.PatientDetails.ToList();

            var appointmentDetailDto = (from al in appointmentList
         join pl in patientList on al.PatientId equals pl.Id
         select new AppointmentDto
         {
             Id = al.Id,
             TokenNo = al.TokenNo,
             DoctorName = al.DoctorName,
             PatientId = al.PatientId,
             Pat= new List<PatientDto>
              
             {
         new Application.PatientDetailDTOs.PatientDetailDto
         {
             Id = patientDetail.Id,
             FirstName = patientDetail.FirstName,
             LastName = patientDetail.LastName,
             Gender = patientDetail.Gender,
             DateOfBirth = patientDetail.DateOfBirth,
             Address = patientDetail.Address,


         }
             }
         }
     ).ToList();

            return Ok(appointmentDetailDto);
        }
    }
}
