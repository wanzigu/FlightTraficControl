using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;

namespace FlightTraficControl
{
    public class FlightInfo
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FlightNo { get; set; }
        public string FlightType { get; set;}
        public string FlightStatus { get; set;}
        public DateTime Timestamp { get; set;} = DateTime.Now;
    }
}
