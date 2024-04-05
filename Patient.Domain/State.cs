using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Domain
{
    public class State
    {
        public int Id { get; set; }
        public string? StateName { get; set; }

        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country? Country { get; set; }   
    }
}
