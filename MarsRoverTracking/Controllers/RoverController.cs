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

        //public RoverController(IRoverService roverService)
        //{
        //    _roverService = roverService;
        //}

        [HttpGet]
        public HttpResponseMessage GetRoverPosition(string roverId)
        {
            return null;
        }


        [HttpPut]
        //[Route("api/rover/move")]
        public HttpResponseMessage MoveRover(string roverId)
        {
            return null;

        }





    }
}
