using microminer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microminer.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {

        private DataDBContext dbContext;
        Microminer microMiner;
        public SearchController(DataDBContext dataDBContext)
        {
            this.dbContext = dataDBContext;
            microMiner = new Microminer(dbContext);
        }


        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]JObject value)
        {
            String input = value["input"].ToString();

            StringBuilder sb = new StringBuilder();
            foreach(String line in microMiner.GetMatches(input))
            {
                sb.Append(line);
                sb.Append('\n');
            }

            if(sb.Length == 0)
            {
                return new ObjectResult(new ResultDetial
                {

                    data = "No match found!"
                });

            }else
            {
                return new ObjectResult(new ResultDetial
                {

                    data = sb.ToString()
                });
            }

        }


        public class ResultDetial
        {
            public String data { get; set; }
        }

    }
}
