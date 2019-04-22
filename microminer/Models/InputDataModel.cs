using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace microminer.Models
{
    public class InputDataModel
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        public string Input { get; set; }
    }
}
