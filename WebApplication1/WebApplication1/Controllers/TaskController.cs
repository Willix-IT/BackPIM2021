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


    public class TaskController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{id}")]
        public SQLModel.Task Get(int id)
        {
            SQLApp.TaskUtils TaskUtils = new SQLApp.TaskUtils();
            SQLModel.Task result = TaskUtils.getOne(id);
            return result;

        }

        // GET api/<ValuesController>/5
        [HttpGet("GetAll")]
        public List<SQLModel.Task> GetAll()
        {
            SQLApp.TaskUtils TaskUtils = new SQLApp.TaskUtils();
            List<SQLModel.Task> result = TaskUtils.getAll();
            return result;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(SQLModel.Task temp)
        {
            SQLApp.TaskUtils TaskUtils = new SQLApp.TaskUtils();
            TaskUtils.createOne(temp);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, SQLModel.Task temp)
        {
            SQLApp.TaskUtils TaskUtils = new SQLApp.TaskUtils();
            TaskUtils.updateOne(temp, id);
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SQLApp.TaskUtils TaskUtils = new SQLApp.TaskUtils();
            TaskUtils.deleteOne(id);
        }
    }
}
