using Microsoft.AspNetCore.Mvc;
using People.Service.Models;
using PersonReader.Interface;
using System.Collections.Generic;
using System.Linq;

namespace People.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        IPeopleProvider provider;

        public PeopleController(IPeopleProvider provider)
        {
            this.provider = provider;
        }

        // GET /people
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return provider.GetPeople();
        }

        // GET /people/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return provider.GetPeople().FirstOrDefault(p => p.Id == id);
        }
    }
}
