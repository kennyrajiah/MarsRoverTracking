using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarsRoverTracking.Models;

namespace MarsRoverTracking.Service.Interface
{
    public interface IRoverService
    {
        RoverModel GetRover(string id);
        RoverModel MoveRover(RoverUpdateModel roverCommandModel);
        

    }
}