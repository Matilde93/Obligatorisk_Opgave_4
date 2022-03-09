using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using REST_ObligatoriskOpgave.Managers;
using REST_ObligatoriskOpgave.Models;

namespace REST_ObligatoriskOpgave.Controllers
{
    [Route("cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private static readonly string CarsCache = "cars";
        private readonly IMemoryCache _memoryCache;
        private CarManager _manager = new CarManager();

        public CarsController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        // GET: api/<CarsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            IEnumerable<Car> cars = null;

            if (_memoryCache.TryGetValue(CarsCache, out cars))
            {
                return cars;
            }

            cars = _manager.GetAll();

            var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30));
            _memoryCache.Set(CarsCache, cars, cacheOptions);

            return cars;
        }

        

        // GET api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return _manager.GetById(id);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{price}")]
        public List<Car> GetListByMaxPrice(double price)
        {
            return _manager.FilteredByMaxPrice(price);
        }

        // POST api/<CarsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public Car Post([FromBody] Car newCar)
        {
            return _manager.AddCar(newCar);
        }


        // DELETE api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public Car Delete(int id)
        {
            return _manager.Delete(id);
        }
    }
}

