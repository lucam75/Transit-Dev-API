using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Transit_Dev_API_1.Models
{
    public class Buses
    {
        /// <summary>
        /// This entity's id.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        ///  License of the bus
        /// </summary>
        [BsonElement("license_plate")]
        public string license_plate { get; set; }
    }
}
