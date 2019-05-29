using System.Collections.Generic;
using System.Linq;
using Transit_Dev_API_1.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Transit_Dev_API_1.Services
{
    public class ProgrammedStopService
    {
        private readonly IMongoCollection<PunctualityResponse> _stops;
        private readonly IMongoCollection<Buses> _buses;

        public ProgrammedStopService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("TransitDb"));
            var database = client.GetDatabase("transit_test");
            _stops = database.GetCollection<PunctualityResponse>("programmed_stops");
            _buses = database.GetCollection<Buses>("buses");
        }

        public List<PunctualityResponse> Get()
        {
            return _stops.Find(p => true).ToList();
        }

        public PunctualityResponse Get(string id)
        {
            return _stops.Find<PunctualityResponse>(p => p.Id == id).FirstOrDefault();
        }

        public List<PunctualityResponse> GetStopsByBusId(string bus_id)
        {
            return _stops.Find<PunctualityResponse>(p => p.BusId == bus_id).ToList();
        }

        public List<PunctualityResponse> GetStopsByTime(decimal programmedTime)
        {
            return _stops.Find<PunctualityResponse>(p => p.ProgrammedTime >= programmedTime).ToList();
        }

        public Buses GetBus(string bus_id)
        {
            return _buses.Find<Buses>(x => x.Id == bus_id).FirstOrDefault();
        }

    }
}
