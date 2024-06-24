using Patient.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DOB { get; set; }
        public string? Gender { get; set; }

        public string? Address { get; set; }
        public int CityId { get; set; }

        public List<CityDto>? Cities_Details { get; set; }
        public List<AppointmentDto>? Appointments_Details { get; set; }
    }
}
