using API_practice.Interface;
using API_practice.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_practice.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class DealerController : ControllerBase
    {
        private readonly IDealerInterface _dealerInterface;
        public DealerController(IDealerInterface dealerInterface)
        {
            _dealerInterface = dealerInterface;
        }

        // GET: api/<DealerController>
        [HttpGet]
        public List<DealerClass> Get()
        {
            var dealer = _dealerInterface.GetAll();
            return dealer;
        }

        // GET api/<DealerController>/5
        [HttpGet("{id}")]
        public DealerClass Get(int DealerId)
        {
            var dealer = _dealerInterface.GetById(DealerId);
            return dealer;
        }

        // POST api/<DealerController>
        [HttpPost]
        public void Post([FromBody] DealerClass dealerClass)
        {
            _dealerInterface.Insert(dealerClass);
        }

        // PUT api/<DealerController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] DealerClass dealerClass, int DealerId)
        {
            _dealerInterface.Update(dealerClass, DealerId);
        }

        // DELETE api/<DealerController>/5
        [HttpDelete("{id}")]
        public void Delete(int DealerId)
        {
            _dealerInterface.Delete(DealerId);
        }
    }
}
