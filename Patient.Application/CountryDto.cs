using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Domain
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string? CountryName { get; set; }
    }
}
