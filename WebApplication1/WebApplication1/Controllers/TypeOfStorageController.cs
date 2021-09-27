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


    public class TypeOfStorageController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{id}")]
        public TypeOfStorage Get(int id)
        {
            SQLApp.TypeOfStorageUtils TypeOfStorageUtils = new SQLApp.TypeOfStorageUtils();
            TypeOfStorage result = TypeOfStorageUtils.getOne(id);
            return result;
            
        }

        // GET api/<ValuesController>/5
        [HttpGet("GetAll")]
        public List<TypeOfStorage> GetAll()
        {
            SQLApp.TypeOfStorageUtils TypeOfStorageUtils = new SQLApp.TypeOfStorageUtils();
            List<TypeOfStorage> result = TypeOfStorageUtils.getAll();
            return result;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(TypeOfStorage temp)
        {
            SQLApp.TypeOfStorageUtils TypeOfStorageUtils = new SQLApp.TypeOfStorageUtils();
            TypeOfStorageUtils.createOne(temp);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, TypeOfStorage temp)
        {
            SQLApp.TypeOfStorageUtils TypeOfStorageUtils = new SQLApp.TypeOfStorageUtils();
            TypeOfStorageUtils.updateOne(temp, id);
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SQLApp.TypeOfStorageUtils TypeOfStorageUtils = new SQLApp.TypeOfStorageUtils();
            TypeOfStorageUtils.deleteOne(id);
        }
    }
}
