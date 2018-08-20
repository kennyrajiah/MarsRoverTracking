using MarsRoverTracking.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MarsRoverTracking.Models;

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
        public HttpResponseMessage GetRover(string roverId)
        {
            var rover = _roverService.GetRover(roverId);
            if (rover == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Could not Locate RoverId:" + roverId + " ,Please Create/Update a Rover!");

            return Request.CreateResponse(HttpStatusCode.OK, "Located RoverId:" + rover.Id +  " at :(" + rover.CurrentX + "," + rover.CurrentY + ")"+ rover.CurrentDirection );
        }


        [HttpPost]
        //[Route("api/rover/move")]
        public HttpResponseMessage MoveRover(RoverUpdateModel roverUpdateModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Incorrect Data,please check your parameters!");
            
            //Check if rover exist First
            var roverModel = _roverService.GetRover(roverUpdateModel.Id);

            if (roverModel == null)
                roverModel = _roverService.CreateRover(roverUpdateModel);
              
            _roverService.SetPosition(roverModel.CurrentX, roverModel.CurrentY);
            _roverService.Process(roverUpdateModel.MovementInstruction);
            var finalRoverPosition = _roverService.RoverCurrentPosition(roverUpdateModel.Id);
            _roverService.UpdateRover(finalRoverPosition);

            return Request.CreateResponse(HttpStatusCode.OK, "Updated RoverId:" + finalRoverPosition.Id +"moved to :(" + finalRoverPosition.CurrentX + "," + finalRoverPosition.CurrentY + ")" + finalRoverPosition.CurrentDirection);

        }





    }
}
