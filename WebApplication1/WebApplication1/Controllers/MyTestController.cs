using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/MyTestController")]
    public class MyTestController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            SQLApp.SQLUtils DBB = new SQLApp.SQLUtils();
            SQLApp.MyTestUtils testUtils = new SQLApp.MyTestUtils();

            //SQLModel.TestModel test = new SQLModel.TestModel();
            //test.nom = "nom2";
            //test.prenom = "prenom2";
            //test.adresse = "adresse2";
            //test.age = "age2";

            return "Salut";

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
