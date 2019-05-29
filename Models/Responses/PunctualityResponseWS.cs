using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Transit_Dev_API_1.Models.Responses
{
    public class PunctualityResponseWS
    {
        /// <summary>
        /// The id of the bus for which this programmed time applies.
        /// </summary>
        [BsonElement("bus_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string bus_id { get; set; }

        /// <summary>
        /// The id of the bus for which this programmed time applies.
        /// </summary>
        [BsonElement("bus_license_plate")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string bus_license_plate { get; set; }

        public Newtonsoft.Json.Linq.JObject next_stop { get; set; }

        public PunctualityResponseWS()
        {
            next_stop = new Newtonsoft.Json.Linq.JObject();
        }
    }
}
