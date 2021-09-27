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


    public class TravelHistoryController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{id}")]
        public TravelHistory Get(int id)
        {
            SQLApp.TravelHistoryUtils TravelHistoryUtils = new SQLApp.TravelHistoryUtils();
            TravelHistory result = TravelHistoryUtils.getOne(id);
            return result;

        }

        // GET api/<ValuesController>/5
        [HttpGet("GetAll")]
        public List<TravelHistory> GetAll()
        {
            SQLApp.TravelHistoryUtils TravelHistoryUtils = new SQLApp.TravelHistoryUtils();
            List<TravelHistory> result = TravelHistoryUtils.getAll();
            return result;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(TravelHistory temp)
        {
            SQLApp.TravelHistoryUtils TravelHistoryUtils = new SQLApp.TravelHistoryUtils();
            TravelHistoryUtils.createOne(temp);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, TravelHistory temp)
        {
            SQLApp.TravelHistoryUtils TravelHistoryUtils = new SQLApp.TravelHistoryUtils();
            TravelHistoryUtils.updateOne(temp, id);
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SQLApp.TravelHistoryUtils TravelHistoryUtils = new SQLApp.TravelHistoryUtils();
            TravelHistoryUtils.deleteOne(id);
        }
    }
}
