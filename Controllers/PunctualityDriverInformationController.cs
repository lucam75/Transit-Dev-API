﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using Transit_Dev_API_1.Models;
using Transit_Dev_API_1.Services;

namespace Transit_Dev_API_1.Controllers
{
    // The following endpoints will be accesible on http://localhost:57089/api/punctualitydriverinformation

    [Route("api/[controller]")]
    public class PunctualityDriverInformationController : Controller
    {
        private readonly ProgrammedStopService _stopService;

        public PunctualityDriverInformationController(ProgrammedStopService service)
        {
            this._stopService = service;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // The following statement gets all the programmed stops. 
            // TODO: Replace it appropriately.
            var result = this._stopService.Get();

            // TODO: Implement your logic.
            //fetch the details from CustomerDB and pass into view  
            // TODO: The following line is just a placeholder you should replace. You can change this method's return type, too.
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public Transit_Dev_API_1.Models.Responses.PunctualityResponseWS Post([FromBody]JObject data)
        {
            Transit_Dev_API_1.Models.Responses.PunctualityResponseWS response = new Models.Responses.PunctualityResponseWS();
            try
            {
                if (data != null && data["bus_id"] != null)
                {
                    // Get parameters
                    string bus_id = Convert.ToString(data["bus_id"]);
                    decimal distance_from_origin_km = Convert.ToDecimal(data["distance_from_origin_km"].ToString());

                    //Get next stop by distance
                    List<PunctualityResponse> stopsByDistance = this._stopService.GetStopsByBusId(bus_id);
                    stopsByDistance = stopsByDistance.OrderBy(x => x.DistanceFromOriginKm).ToList();

                    //Get next stop by time
                    DateTime now = DateTime.Now;
                    Decimal minute = Decimal.Parse(((now.Minute * 10 / 60)).ToString());
                    Decimal hour = Convert.ToDecimal(now.ToString("HH"));
                    
                    decimal currentTime = hour + (minute/10);
                    //hack to simulate an hour
                    currentTime = Decimal.Parse("14.7");

                    List<PunctualityResponse> stopsByTime = this._stopService.GetStopsByBusId(bus_id);
                    stopsByTime = stopsByTime.OrderBy(x => x.ProgrammedTime).ToList();

                    //Get bus data
                    Buses bus = this._stopService.GetBus(bus_id);

                    //Populate answer
                    response.bus_id = bus_id;
                    response.bus_license_plate = bus.license_plate;
                    response.next_stop["by_distance"] = JToken.FromObject(stopsByDistance.Find(x => x.DistanceFromOriginKm > distance_from_origin_km));
                    response.next_stop["by_program"] = JToken.FromObject(stopsByTime.Find(x => x.ProgrammedTime >= currentTime));

                }
            }
            catch(Exception e)
            {

            }
            
            return response;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
