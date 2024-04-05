using Patient.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application
{
    public class CityDto
    {
        public int Id { get; set; }
        public string? CityName { get; set; }

        public int StateId { get; set; }
    }
}
