using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int TokenNo { get; set; }
        public string? DoctorName { get; set; }
        public int PatientId { get; set; }
        public List<CityDto>? Cities_Details { get; set; }
        public List<PatientDto>? Patients_Details { get; set; }
    }
}
