using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarsRoverTracking.Models;

namespace MarsRoverTracking.Repositories.Interface
{
    public interface IRoverRepository
    {
        RoverModel CreateRoverInfo(string id);
        RoverModel ReadRoverInfo(string id);
        RoverModel UpdateRoverInfo(RoverModel roverModel);
    }
}