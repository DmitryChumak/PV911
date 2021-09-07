using CarShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly CarContext context;

        public CarsController(CarContext context)
        {
            this.context = context;
        }

        //[HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> Get()
        {
            return await context.Cars.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            Car car = await context.Cars.FirstOrDefaultAsync(x => x.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> Post(Car car)
        {
            context.Cars.Add(car);
            await context.SaveChangesAsync();
            return Ok(car);
        }

        [HttpPut]
        public async Task<ActionResult<Car>> Put(Car car)
        {
            context.Update(car);
            await context.SaveChangesAsync();
            return Ok(car);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> Delete(int id)
        {
            Car car = await context.Cars.FirstOrDefaultAsync(x => x.CarId == id);
            if (car == null)
            {
                return NotFound();
            }
            context.Cars.Remove(car);
            await context.SaveChangesAsync();
            return Ok(car);
        }

    }
}
