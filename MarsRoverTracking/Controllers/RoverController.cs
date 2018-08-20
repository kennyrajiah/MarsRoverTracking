using MarsRoverTracking.Service.Interface;
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
        [Route("v1/rover/{id:length(1,10)}")]
        public HttpResponseMessage GetRover(string id)
        {
            var rover = _roverService.GetRover(id);
            if (rover == null)
                     return Request.CreateResponse(HttpStatusCode.NotFound, $"Could not Locate RoverId: {id},Please Create/Update a Rover!");

        
            return Request.CreateResponse(HttpStatusCode.OK, $"Located RoverId: {id} at :({rover.CurrentX},{rover.CurrentY}) {rover.CurrentDirection}");
        }
  

        [HttpPost]
        [Route("v1/rover/move")]
        public HttpResponseMessage MoveRover(RoverUpdateModel roverUpdateModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest,$"Incorrect Data,please check your parameters!");
            
            //Check if rover exist First
            var roverModel = _roverService.GetRover(roverUpdateModel.Id);

            if (roverModel == null)
                roverModel = _roverService.CreateRover(roverUpdateModel);
              
            _roverService.SetPosition(roverModel.CurrentX, roverModel.CurrentY);
            _roverService.Process(roverUpdateModel.MovementInstruction);
            var finalRoverPosition = _roverService.RoverCurrentPosition(roverUpdateModel.Id);
            _roverService.UpdateRover(finalRoverPosition);


               return Request.CreateResponse(HttpStatusCode.OK, $"Updated RoverId: { finalRoverPosition.Id} ,moved to :({finalRoverPosition.CurrentX}, { finalRoverPosition.CurrentY }){ finalRoverPosition.CurrentDirection}");

  

        }





    }
}
