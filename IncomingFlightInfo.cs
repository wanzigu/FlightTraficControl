using MongoDB.Driver;

namespace FlightTraficControl
{
    public class IncomingFlightInfo
    {
        private List<FlightInfo> flightLandings = new List<FlightInfo>() { };
        //    new FlightInfo
        //    {
        //        FlightNo = "Flight 565",
        //        FlightType = "Airbus 300",
        //        FlightStatus = "landing",
        //        Timestamp = DateTime.Now,
        //    },
        //    new FlightInfo
        //    {
        //        FlightNo = "Flight 535",
        //        FlightType = "Airbus 359",
        //        FlightStatus = "landing",
        //        Timestamp = DateTime.Now,
        //    },
        //    new FlightInfo
        //    {
        //        FlightNo = "Flight 888",
        //        FlightType = "Boeing 747",
        //        FlightStatus = "landing",
        //        Timestamp = DateTime.Now,
        //    },
        //        new FlightInfo
        //    {
        //        FlightNo = "Flight 565",
        //        FlightType = "Airbus 303",
        //        FlightStatus = "landing",
        //        Timestamp = DateTime.Now,
        //    },
        //    new FlightInfo
        //    {
        //        FlightNo = "Flight 855",
        //        FlightType = " Boeing 747",
        //        FlightStatus = "landing",
        //        Timestamp = DateTime.Now,
        //    },
        //    new FlightInfo
        //    {
        //        FlightNo = "Flight 565",
        //        FlightType = "Airbus 300",
        //        FlightStatus = "landing",
        //        Timestamp = DateTime.Now,
        //    },
        //    new FlightInfo
        //    {
        //        FlightNo = "Flight 535",
        //        FlightType = "Airbus 359",
        //        FlightStatus = "landing",
        //        Timestamp = DateTime.Now,
        //    },
        //    new FlightInfo
        //    {
        //        FlightNo = "Flight 888",
        //        FlightType = "Boeing 747",
        //        FlightStatus = "landing",
        //        Timestamp = DateTime.Now,
        //    },
        //        new FlightInfo
        //    {
        //        FlightNo = "Flight 565",
        //        FlightType = "Airbus 303",
        //        FlightStatus = "landing",
        //        Timestamp = DateTime.Now,
        //    },
        //    new FlightInfo
        //    {
        //        FlightNo = "Flight 855",
        //        FlightType = " Boeing 747",
        //        FlightStatus = "landing",
        //        Timestamp = DateTime.Now,
        //    }
        //};

        private List<FlightInfo> flightDepartures = new List<FlightInfo>() { };
        //    new FlightInfo
        //    {
        //        FlightNo = "Flight 812",
        //        FlightType = "Boeing 737",
        //        FlightStatus = "departure",
        //        Timestamp = DateTime.Now,
        //    },
        //    new FlightInfo
        //    {
        //        FlightNo = "Flight 813",
        //        FlightType = "Boeing 737",
        //        FlightStatus = "departure",
        //        Timestamp = DateTime.Now,
        //    },
        //    new FlightInfo
        //    {
        //        FlightNo = "Flight 779",
        //        FlightType = "Airbus 343",
        //        FlightStatus = "departure",
        //        Timestamp = DateTime.Now,
        //    },
        //    new FlightInfo
        //    {
        //        FlightNo = "Flight 576",
        //        FlightType = "Airbus 350",
        //        FlightStatus = "departure",
        //        Timestamp = DateTime.Now,
        //    },
        //    new FlightInfo
        //    {
        //        FlightNo = "Flight 812",
        //        FlightType = "Boeing 737",
        //        FlightStatus = "departure",
        //        Timestamp = DateTime.Now,
        //    },
        //    new FlightInfo
        //    {
        //        FlightNo = "Flight 813",
        //        FlightType = "Boeing 737",
        //        FlightStatus = "departure",
        //        Timestamp = DateTime.Now,
        //    },
        //    new FlightInfo
        //    {
        //        FlightNo = "Flight 779",
        //        FlightType = "Airbus 343",
        //        FlightStatus = "departure",
        //        Timestamp = DateTime.Now,
        //    },
        //    new FlightInfo
        //    {
        //        FlightNo = "Flight 576",
        //        FlightType = "Airbus 350",
        //        FlightStatus = "departure",
        //        Timestamp = DateTime.Now,
        //    },
        //};

        private List<FlightInfo> airborneFlights = new List<FlightInfo>() { };
        private List<FlightInfo> standbyFlights = new List<FlightInfo>() { };
        private List<FlightInfo> allFlightInfo = new List<FlightInfo>() { };
        private List<ControllerInstruction> controllerInstructions = new List<ControllerInstruction>() { };
        private ControllerInstruction controllerInstruction = new ControllerInstruction() { };

        public async Task ReceivesFlightLanding(FlightInfo newFlightInfo)
        {
            var connectionString = "mongodb+srv://wanziguelva:hcHxxK96TrHsLmnr@testing.rff3vvp.mongodb.net/?retryWrites=true&w=majority";
            MongoClient dbClient = new MongoClient(connectionString);

            var _landing = dbClient.GetDatabase("Landing");
            var collection = _landing.GetCollection<FlightInfo>("landing");
            await collection.InsertOneAsync(newFlightInfo); 
        }

        public async Task ReceivesFlightDeparture(FlightInfo newFlightInfo)
        {
            var connectionString = "mongodb+srv://wanziguelva:hcHxxK96TrHsLmnr@testing.rff3vvp.mongodb.net/?retryWrites=true&w=majority";
            MongoClient dbClient = new MongoClient(connectionString);

            var _departure = dbClient.GetDatabase("Landing");
            var collection = _departure.GetCollection<FlightInfo>("landing");
            await collection.InsertOneAsync(newFlightInfo);
            
        }

        public async Task<List<FlightInfo>> LatestFlightLandings()
        {
            var connectionString = "mongodb+srv://wanziguelva:hcHxxK96TrHsLmnr@testing.rff3vvp.mongodb.net/?retryWrites=true&w=majority";
            MongoClient dbClient = new MongoClient(connectionString);

            var _landing = dbClient.GetDatabase("Landing");
            var collection = _landing.GetCollection<FlightInfo>("landing");
            var filter = Builders<FlightInfo>.Filter.Empty;
            flightLandings = collection.Find(filter).ToList();
            return flightLandings;
        }

        public async Task<List<FlightInfo>> LatestFlightDepartures()
        {
            var connectionString = "mongodb+srv://wanziguelva:hcHxxK96TrHsLmnr@testing.rff3vvp.mongodb.net/?retryWrites=true&w=majority";
            MongoClient dbClient = new MongoClient(connectionString);

            var _departure = dbClient.GetDatabase("Departure");
            var collection = _departure.GetCollection<FlightInfo>("departure");
            var filter = Builders<FlightInfo>.Filter.Empty;
            flightDepartures  = collection.Find(filter).ToList();
            return flightDepartures;
        }

        public async Task<List<FlightInfo>> AirborneFlights()
        {
            var connectionString = "mongodb+srv://wanziguelva:hcHxxK96TrHsLmnr@testing.rff3vvp.mongodb.net/?retryWrites=true&w=majority";
            MongoClient dbClient = new MongoClient(connectionString);

            var _airborne = dbClient.GetDatabase("Airborne");
            var collection = _airborne.GetCollection<FlightInfo>("airborne");
            var filter = Builders<FlightInfo>.Filter.Empty;
            airborneFlights = collection.Find(filter).ToList();
            return airborneFlights;
        }

        public async Task<List<FlightInfo>> StandbyFlights()
        {
            var connectionString = "mongodb+srv://wanziguelva:hcHxxK96TrHsLmnr@testing.rff3vvp.mongodb.net/?retryWrites=true&w=majority";
            MongoClient dbClient = new MongoClient(connectionString);

            var _standby = dbClient.GetDatabase("Standby");
            var collection = _standby.GetCollection<FlightInfo>("standby");
            var filter = Builders<FlightInfo>.Filter.Empty;
            standbyFlights = collection.Find(filter).ToList();
            return standbyFlights;
        }

        public async Task<List<ControllerInstruction>> HistoricalControlInstructions()
        {
            //allFlightInfo.AddRange(flightLandings);
            //allFlightInfo.AddRange(flightDepartures);
            //List<FlightInfo> orderedFlightInfo = allFlightInfo.OrderBy(f => f.Timestamp).ToList();

            //foreach (var flightInfo in orderedFlightInfo)
            //{
            //    ControllerInstruction controllerInstruction = new ControllerInstruction
            //    {
            //        FlightNo = flightInfo.FlightNo,
            //        FlightType = flightInfo.FlightType,
            //        Instruction = flightInfo.FlightStatus,
            //        Timestamp = DateTime.Now,
            //    };
            //    controllerInstructions.Add(controllerInstruction);
            //}
            var connectionString = "mongodb+srv://wanziguelva:hcHxxK96TrHsLmnr@testing.rff3vvp.mongodb.net/?retryWrites=true&w=majority";
            MongoClient dbClient = new MongoClient(connectionString);

            var _historicalInstruction = dbClient.GetDatabase("HistoricalInstructions");
            var collection = _historicalInstruction.GetCollection<ControllerInstruction>("historicalInstructions");
            var filter = Builders<ControllerInstruction>.Filter.Empty;

            controllerInstructions = collection.Find(filter).ToList();
            return controllerInstructions;
        }

        public async Task<ControllerInstruction>? CurrentControllerInstruction()
        {
            var connectionString = "mongodb+srv://wanziguelva:hcHxxK96TrHsLmnr@testing.rff3vvp.mongodb.net/?retryWrites=true&w=majority";
            MongoClient dbClient = new MongoClient(connectionString);

            var _airborne = dbClient.GetDatabase("Airborne");
            var airborneCollection = _airborne.GetCollection<FlightInfo>("airborne");

            var _standby = dbClient.GetDatabase("Standby");
            var standbyCollection = _standby.GetCollection<FlightInfo>("standby");

            var _landing = dbClient.GetDatabase("Landing");
            var landingCollection = _landing.GetCollection<FlightInfo>("landing");

            var _departure = dbClient.GetDatabase("Departure");
            var departureCollection = _departure.GetCollection<FlightInfo>("departure");

            var _historicalInstruction = dbClient.GetDatabase("HistoricalInstructions");
            var collection = _historicalInstruction.GetCollection<ControllerInstruction>("historicalInstructions");

            var filter = Builders<ControllerInstruction>.Filter.Empty;
            controllerInstructions = collection.Find(filter).ToList();

            List<ControllerInstruction> orderedControllerInstructions = controllerInstructions.OrderBy(f => f.Timestamp).ToList();
            controllerInstruction = orderedControllerInstructions.FirstOrDefault()!;

            var currentFlight = new FlightInfo{ 
                FlightNo = controllerInstruction.FlightNo,
                FlightType = controllerInstruction.FlightType,
                FlightStatus = controllerInstruction.Instruction
            };
            if (controllerInstruction?.Instruction == "landing")
            {
                await standbyCollection.InsertOneAsync(currentFlight);
                await landingCollection.DeleteOneAsync(a => a.FlightNo == currentFlight.FlightNo && a.FlightType == currentFlight.FlightType);
            } else
            {
                await airborneCollection.InsertOneAsync(currentFlight);
                await departureCollection.DeleteOneAsync(a => a.FlightNo == currentFlight.FlightNo && a.FlightType == currentFlight.FlightType);       
            }

            await collection.DeleteOneAsync(a => a.FlightNo == currentFlight.FlightNo && a.FlightType == currentFlight.FlightType);
            return controllerInstruction;
        }
    }
}
