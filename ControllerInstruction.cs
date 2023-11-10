using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;

namespace FlightTraficControl
{
    public class ControllerInstruction 
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? FlightNo { get; set; }
        public string? FlightType { get; set; }
        public string? Instruction { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
