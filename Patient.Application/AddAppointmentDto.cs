using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application
{
    public class AddAppointmentDto
    {
        public int TokenNo { get; set; }
        public string? DoctorName { get; set; }
        public int PatientId { get; set; }
    }
}
