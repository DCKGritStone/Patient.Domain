using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Domain.Application
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int TokenNo { get; set; }
        public string? DoctorName { get; set; }
        public int PatientId { get; set; }

        List<PatientDetail> Patients_Details { get; set; }
        List<City> Cities_Details { get; set; }
        
        List <State> State_Details { get; set; }

        List <Country> Country_Details { get; set; }
    }
}
