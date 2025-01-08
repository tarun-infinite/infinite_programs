using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assessment_1.Models;


namespace Assessment_1.Controllers
{
    public class CountryController : ApiController
    {

        //[RoutePrefix("api/Country")]
       
            private static List<Country> countries = new List<Country>
        {
            new Country { ID = 1, CountryName = "sri lanka", Capital = "colombo" },
            new Country { ID = 2, CountryName = "japan", Capital = "tokyo" }
        };

            [HttpGet]
            [Route("")]
            public IHttpActionResult GetAllCountries()
            {
                return Ok(countries);
            }

            [HttpGet]
            [Route("{id:int}")]
            public IHttpActionResult GetCountryById(int id)
            {
                var country = countries.FirstOrDefault(c => c.ID == id);
                if (country == null)
                    return NotFound();
                return Ok(country);
            }

            [HttpPost]
            [Route("")]
            public IHttpActionResult AddCountry([FromBody] Country country)
            {
                if (country == null)
                    return BadRequest("Invalid data.");
                countries.Add(country);
                return Ok(country);
            }

            [HttpPut]
            [Route("{id:int}")]
            public IHttpActionResult UpdateCountry(int id, [FromBody] Country updatedCountry)
            {
                var country = countries.FirstOrDefault(c => c.ID == id);
                if (country == null)
                    return NotFound();

                country.CountryName = updatedCountry.CountryName;
                country.Capital = updatedCountry.Capital;
                return Ok(country);
            }

            [HttpDelete]
            [Route("{id:int}")]
            public IHttpActionResult DeleteCountry(int id)
            {
                var country = countries.FirstOrDefault(c => c.ID == id);
                if (country == null)
                    return NotFound();

                countries.Remove(country);
                return Ok();
            }
        }
    }

