using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Domain
{
    public class City
    {
        [ForeignKey("StateId")]
        public int Id { get; set; }
        public string? CityName { get; set; }

        public int StateId { get; set; }

        /*
        public State? State { get; set; }*/
    }
}
