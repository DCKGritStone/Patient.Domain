using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Domain
{
    public class AppointmentDetail
    {

       public int Id { get; set; }
        public int TokenNo { get; set; }
        public string? DoctorName { get; set; }

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public PatientDetail? PatientDetail { get; set;}

        
    }
}
