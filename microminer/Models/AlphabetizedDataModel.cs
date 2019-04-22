using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace microminer.Models
{
    public class AlphabetizedDataModel
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        public string Alphabetized { get; set; }
    }
}
