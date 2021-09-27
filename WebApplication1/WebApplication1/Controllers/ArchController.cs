using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SQLModel;

// For more information on enabling Web API for empty Archs, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ArchController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{id}")]
        public Arch Get(int id)
        {
            SQLApp.ArchUtils ArchUtils = new SQLApp.ArchUtils();
            Arch result = ArchUtils.getOne(id);
            return result;

        }

        // GET api/<ValuesController>/5
        [HttpGet("GetAll")]
        public List<Arch> GetAll()
        {
            SQLApp.ArchUtils ArchUtils = new SQLApp.ArchUtils();
            List<Arch> result = ArchUtils.getAll();
            return result;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(Arch temp)
        {
            SQLApp.ArchUtils ArchUtils = new SQLApp.ArchUtils();
            ArchUtils.createOne(temp);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, Arch temp)
        {
            SQLApp.ArchUtils ArchUtils = new SQLApp.ArchUtils();
            ArchUtils.updateOne(temp, id);
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SQLApp.ArchUtils ArchUtils = new SQLApp.ArchUtils();
            ArchUtils.deleteOne(id);
        }
    }
}
