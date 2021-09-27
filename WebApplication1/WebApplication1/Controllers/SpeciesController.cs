using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SQLModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class SpeciesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{id}")]
        public Species Get(int id)
        {
            SQLApp.SpeciesUtils SpeciesUtils = new SQLApp.SpeciesUtils();
            Species result = SpeciesUtils.getOne(id);
            return result;

        }

        // GET api/<ValuesController>/5
        [HttpGet("GetAll")]
        public List<Species> GetAll()
        {
            SQLApp.SpeciesUtils SpeciesUtils = new SQLApp.SpeciesUtils();
            List<Species> result = SpeciesUtils.getAll();
            return result;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(Species temp)
        {
            SQLApp.SpeciesUtils SpeciesUtils = new SQLApp.SpeciesUtils();
            SpeciesUtils.createOne(temp);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, Species temp)
        {
            SQLApp.SpeciesUtils SpeciesUtils = new SQLApp.SpeciesUtils();
            SpeciesUtils.updateOne(temp, id);
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SQLApp.SpeciesUtils SpeciesUtils = new SQLApp.SpeciesUtils();
            SpeciesUtils.deleteOne(id);
        }
    }
}
