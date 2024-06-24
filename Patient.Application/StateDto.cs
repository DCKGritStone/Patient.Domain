using Patient.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application
{
    public class StateDto
    {
        public int Id { get; set; }
        public string? StateName { get; set; }

        public int CountryId { get; set; }

        public List<CountryDto>? Countries_Details { get; set; }
    }
}
