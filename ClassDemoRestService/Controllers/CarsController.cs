﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestLibrary;
using RestLibrary.model;

namespace ClassDemoRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private static List<Car> data = new List<Car>
        {
            new Car(12, 2018, "rød"),
            new Car(14, 2014, "blå"),
            new Car(14, 2019, "Hvid"),
            new Car(14, 2013, "Sort"),
            new Car(14, 2012, "Gul")
        };
        // GET: api/Cars
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return data;
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return data.Find(c => c.Id == id);
        }

        // POST: api/Cars
        [HttpPost]
        public void Post([FromBody] Car value)
        {
            data.Add(value);
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Car value)
        {
            Car item = Get(id);
            if (item != null)
            {
                item.Id = value.Id;
                item.Year = value.Year;
                item.Color = value.Color;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Car car = Get(id);
            if (car != null)
            {
                data.Remove(car);
            }
            
        }
        //api/Cars/Search?xxxx
       [HttpGet]
        [Route("search")]
        public List<Car> Search([FromQuery] QueryCar qcar)
        {
            List<Car> liste = new List<Car>();

            if (qcar.MaxYear == 0)
            {
                qcar.MaxYear = int.MaxValue;
            }


            foreach (Car car in data)
            {
                if (qcar.MinYear <= car.Year && car.Year <= qcar.MaxYear)
                {
                    liste.Add(car);
                }
            }


            return liste;
        }
    }
}
