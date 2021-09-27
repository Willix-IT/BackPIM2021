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


    public class SiteController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{id}")]
        public Site Get(int id)
        {
            SQLApp.SiteUtils SiteUtils = new SQLApp.SiteUtils();
            Site result = SiteUtils.getOne(id);
            return result;

        }

        // GET api/<ValuesController>/5
        [HttpGet("GetAll")]
        public List<Site> GetAll()
        {
            SQLApp.SiteUtils SiteUtils = new SQLApp.SiteUtils();
            List<Site> result = SiteUtils.getAll();
            return result;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(Site temp)
        {
            SQLApp.SiteUtils SiteUtils = new SQLApp.SiteUtils();
            SiteUtils.createOne(temp);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, Site temp)
        {
            SQLApp.SiteUtils SiteUtils = new SQLApp.SiteUtils();
            SiteUtils.updateOne(temp, id);
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SQLApp.SiteUtils SiteUtils = new SQLApp.SiteUtils();
            SiteUtils.deleteOne(id);
        }
    }
}
