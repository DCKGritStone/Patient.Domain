using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Patient.Application;
using Patient.Domain;
using Patient.Infrastructure;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace PatientClean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsbyAppointmentController : ControllerBase
    {
        private readonly PatientDbContext dbContext;

        public DetailsbyAppointmentController(PatientDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            var appointmentList = dbContext.AppointmentDetails.ToList();
            var patientList = dbContext.PatientDetails.ToList();
            var cityList= dbContext.Cities.ToList();
            var stateList= dbContext.States.ToList();
            var countryList= dbContext.Countries.ToList();

            var appointmentDetailDto = (from al in appointmentList
                                        join pl in patientList on al.PatientId equals pl.Id
                                        join cl in cityList on pl.CityId equals cl.Id 
                                        join sl in stateList on cl.StateId equals sl.Id
                                        join col in countryList on sl.CountryId equals col.Id 
                                        
                                        
                                        select new AppointmentDto

                                        {
                                            Id = al.Id,
                                            TokenNo = al.TokenNo,
                                            DoctorName = al.DoctorName,
                                            PatientId = al.PatientId,
                                            Patients_Details =  new List<PatientDto>
                                            
                                            {new PatientDto
                                            {
                                                 Id= pl.Id,
                                                    FirstName = pl.FirstName,
                                                    LastName = pl.LastName,
                                                    DOB= pl.DOB,
                                                    Gender = pl.Gender,
                                                    Address = pl.Address,
                                                    CityId = pl.CityId,
                                                    Cities_Details=new List<CityDto>
                                                    {
                                                        new CityDto
                                                        {
                                                            Id=cl.Id,
                                                            CityName=cl.CityName,
                                                            StateId=cl.StateId,
                                                            States_Details=new List<StateDto>
                                                            {
                                                                new StateDto
                                                                {
                                                                    Id=sl.Id,
                                                                    StateName=sl.StateName,
                                                                    CountryId=sl.CountryId,
                                                                    Countries_Details=new List<CountryDto>
                                                                    {
                                                                        new CountryDto
                                                                        {
                                                                            Id=col.Id,
                                                                            CountryName=col.CountryName
                                                                        }
                                                                    }
                                                                }
                                                            }

                                                        }
                                                    }
                                            }


                                                   
                                                
                                            }

                                        }).ToList();

            return Ok(appointmentDetailDto);
        }
    }
}
