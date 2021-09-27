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


    public class StorageController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{id}")]
        public Storage Get(int id)
        {
            SQLApp.StorageUtils StorageUtils = new SQLApp.StorageUtils();
            Storage result = StorageUtils.getOne(id);
            return result;

        }

        // GET api/<ValuesController>/5
        [HttpGet("GetAll")]
        public List<Storage> GetAll()
        {
            SQLApp.StorageUtils StorageUtils = new SQLApp.StorageUtils();
            List<Storage> result = StorageUtils.getAll();
            return result;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(Storage temp)
        {
            SQLApp.StorageUtils StorageUtils = new SQLApp.StorageUtils();
            StorageUtils.createOne(temp);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, Storage temp)
        {
            SQLApp.StorageUtils StorageUtils = new SQLApp.StorageUtils();
            StorageUtils.updateOne(temp, id);
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SQLApp.StorageUtils StorageUtils = new SQLApp.StorageUtils();
            StorageUtils.deleteOne(id);
        }
    }
}
