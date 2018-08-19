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

        public RoverService(IRoverRepository roverRepository)
        {
            _roverRepository = roverRepository;
        }


        public RoverModel GetRover(string id)
        {
            var getRover = _roverRepository.ReadRoverInfo(id);

            return getRover;
        }

        public RoverModel MoveRover(RoverUpdateModel roverCommandModel)
        {
            //locate if that rover has been already added
            var getRover = _roverRepository.ReadRoverInfo(roverCommandModel.Id);

            if (getRover==null)
                //create

                return null;

            //var rover = myList[roverCommandModel.Id];
            ////Mapt to MoveRoverModel
            //var moveRoverModel = MapToModelMoveModel(rover.Id, rover.CurrentX, rover.CurrentY, rover.Name, rover.CurrentDirection);

            return getRover;
        }



    }
}