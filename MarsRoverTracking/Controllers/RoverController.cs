using MarsRoverTracking.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MarsRoverTracking.Controllers
{
    
    public class RoverController : ApiController
    {
        private readonly IRoverService _roverService;

        public RoverController(IRoverService roverService)
        {
            _roverService = roverService;
        }

        [HttpGet]
        public HttpResponseMessage GetRoverPosition(string roverId)
        {
            var rover = _roverService.GetRover(roverId);
            if (rover == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Could not Locate RoverId:" + roverId + " ,Please Create/Update a Rover!");

            return Request.CreateResponse(HttpStatusCode.OK, "Located RoverId:" + rover.Id + ", Name:" + rover.Name + " at :(" + rover.CurrentX + "," + rover.CurrentY + ")" + rover.CurrentDirection);
        }


        [HttpPut]
        //[Route("api/rover/move")]
        public HttpResponseMessage MoveRover(string roverId)
        {
            return null;

        }





    }
}
