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
        RoverModel UpdateRover(RoverModel roverModel);
        RoverModel CreateRover(RoverUpdateModel roverModel);
        void SetPosition(int x, int y);
        void Process(string commands);
        RoverModel RoverCurrentPosition(string roverid);

    }
}