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


    public class ProjectController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{id}")]
        public Project Get(int id)
        {
            SQLApp.ProjectUtils ProjectUtils = new SQLApp.ProjectUtils();
            Project result = ProjectUtils.getOne(id);
            return result;

        }

        // GET api/<ValuesController>/5
        [HttpGet("GetAll")]
        public List<Project> GetAll()
        {
            SQLApp.ProjectUtils ProjectUtils = new SQLApp.ProjectUtils();
            List<Project> result = ProjectUtils.getAll();
            return result;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(Project temp)
        {
            SQLApp.ProjectUtils ProjectUtils = new SQLApp.ProjectUtils();
            ProjectUtils.createOne(temp);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, Project temp)
        {
            SQLApp.ProjectUtils ProjectUtils = new SQLApp.ProjectUtils();
            ProjectUtils.updateOne(temp, id);
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SQLApp.ProjectUtils ProjectUtils = new SQLApp.ProjectUtils();
            ProjectUtils.deleteOne(id);
        }
    }
}
