using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarsRoverTracking.Models;
using MarsRoverTracking.Repositories.Interface;
using MarsRoverTracking.Service.Interface;

namespace MarsRoverTracking.Service.Implementation
{
    public class RoverService :IRoverService
    {
        private readonly IRoverRepository _roverRepository;

        public RoverService(/*IRoverRepository roverRepository*/)
        {
            // _roverRepository = roverRepository;
        }


        public RoverModel GetRover(string id)
        {
           

            return null;
        }


    }
}