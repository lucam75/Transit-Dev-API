using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Transit_Dev_API_1.Models
{
    public class PunctualityResponse
    {
        /// <summary>
        /// This entity's id.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        ///  The code for the stop related to this programmed time.
        /// </summary>
        [BsonElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// Linear distance, in km, measured from origin.
        /// </summary>
        [BsonElement("distance_from_origin_km")]
        public decimal DistanceFromOriginKm { get; set; }

        /// <summary>
        /// The id of the bus for which this programmed time applies.
        /// </summary>
        [BsonElement("bus_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BusId { get; set; }

        /// <summary>
        /// The programmed time, as a decimal from 0.0000 (midnight) to 23.9999 (just before midnight), representing 00:00:00.0 and 23:59:59.9, respectively. 
        /// </summary>
        [BsonElement("programmed_time")]
        public decimal ProgrammedTime { get; set; }
    }
}
