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


    public class UserController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{id}")]
        public User Get(int id)
        {
            SQLApp.UserUtils UserUtils = new SQLApp.UserUtils();
            User result = UserUtils.getOne(id);
            return result;

        }

        // GET api/<ValuesController>/5
        [HttpGet("GetAll")]
        public List<User> GetAll()
        {
            SQLApp.UserUtils UserUtils = new SQLApp.UserUtils();
            List<User> result = UserUtils.getAll();
            return result;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(User temp)
        {
            SQLApp.UserUtils UserUtils = new SQLApp.UserUtils();
            UserUtils.createOne(temp);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, User temp)
        {
            SQLApp.UserUtils UserUtils = new SQLApp.UserUtils();
            UserUtils.updateOne(temp, id);
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SQLApp.UserUtils UserUtils = new SQLApp.UserUtils();
            UserUtils.deleteOne(id);
        }
    }
}
