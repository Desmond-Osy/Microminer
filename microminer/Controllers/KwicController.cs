using microminer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microminer.Controllers
{
    [Route("api/[controller]")]
    public class KwicController : Controller
    {
        private DataDBContext dbContext;
        Microminer microMiner;
        public KwicController(DataDBContext dataDBContext)
        {
            this.dbContext = dataDBContext;
            microMiner =  new Microminer(dbContext);
        }

        

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]JObject value)
        {
            String input = value["input"].ToString();
            
            microMiner.SetInput(input);

            return new ObjectResult(new ProcessingDetial {
                data = microMiner.GetAlphabetized()
            });
        }


        public class ProcessingDetial
        {
            public String data { get; set; }
        }

    }
}
