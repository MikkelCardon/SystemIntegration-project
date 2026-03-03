using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemIntegration_project.Database;
using SystemIntegration_project.Models;

namespace SystemIntegration_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly FlightContext _flightContext;
        
        public FlightController(FlightContext flightContext)
        {
            _flightContext = flightContext;
        }
        
        [HttpPost]
        public ActionResult<FlightInfo> Create([FromBody] FlightInfo flightInfo)
        {
            _flightContext.flights.Add(flightInfo);
            _flightContext.SaveChanges();
            
            _flightContext.PrintFlights();

            return flightInfo;
        }
        
        
    }
}
