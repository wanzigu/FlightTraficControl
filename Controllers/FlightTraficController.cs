using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FlightTraficControl.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightTraficController : ControllerBase
    {
        private readonly ILogger<FlightTraficController> _logger;

        //Add dependency injection
        IncomingFlightInfo _flightInfo = new IncomingFlightInfo();

        public FlightTraficController(ILogger<FlightTraficController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/Landings")]
        public async Task<IEnumerable<FlightInfo>> GetLandings()
        {
            var landings = await _flightInfo.LatestFlightLandings();
            return landings;
        }

        [HttpGet("/Departures")]
        public async Task<IEnumerable<FlightInfo>> GetDepartures()
        {
            return await _flightInfo.LatestFlightDepartures();
        }

        [HttpGet("/AirborneFlights")]
        public async Task<IEnumerable<FlightInfo>> GetAirborneFlights()
        {
            return await _flightInfo.AirborneFlights();
        }

        [HttpGet("/StandbyFlights")]
        public async Task<IEnumerable<FlightInfo>> GetStandbyFlights()
        {
            return await _flightInfo.StandbyFlights();
        }

        [HttpPost("/NewLanding")]
        public async Task<string> ReceiveNewLanding([FromBody]FlightInfo flightInfo)
        {
            await _flightInfo.ReceivesFlightLanding(flightInfo);
            return "Please standby and wait for instruction from ATCO";
        }

        [HttpPost("/NewDeparture")]
        public async Task<string> ReceiveNewDeparture([FromBody]FlightInfo flightInfo)
        {
            await _flightInfo.ReceivesFlightDeparture(flightInfo);
            return "Please standby and wait for instruction from ATCO";
        }

        [HttpGet("/CurrentControllerInstruction")]
        public async Task<ControllerInstruction> GetcurrentInstruction()
        {
            ControllerInstruction controllerInstruction = await _flightInfo.CurrentControllerInstruction();
            return controllerInstruction;
        }

        [HttpGet("/HistoricalControllerInstructions")]
        public async Task<IEnumerable<ControllerInstruction>> GetInstructions()
        {
            return await _flightInfo.HistoricalControlInstructions();
        }
    }
}