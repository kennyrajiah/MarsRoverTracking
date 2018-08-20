using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarsRoverTracking.Models;
using MarsRoverTracking.Repositories.Interface;
using MarsRoverTracking.Service.Interface;
using MarsRoverTracking.Utilities;

namespace MarsRoverTracking.Service.Implementation
{
    public class RoverService :IRoverService
    {
        private readonly IRoverRepository _roverRepository;
        private int _x = 0;
        private int _y = 0;
        private int _facing = N;
        private static readonly int N = (int)Cardinals.N;
        private static readonly int E = (int)Cardinals.E;
        private static readonly int S = (int)Cardinals.S;
        private static readonly int W = (int)Cardinals.W;

        public RoverService(IRoverRepository roverRepository)
        {
            _roverRepository = roverRepository;
        }


        public RoverModel GetRover(string id)
        {
            //getRover
            var getRover = _roverRepository.ReadRoverInfo(id);
            return getRover;
        }

        public RoverModel UpdateRover(RoverModel roverModel )
        {
            //UpdateRover
            var getRover = _roverRepository.UpdateRoverInfo(roverModel);
            return getRover;
        }


        public RoverModel CreateRover(RoverUpdateModel roverModel)
        {
            //CreateRover
            var getRover = _roverRepository.CreateRoverInfo(roverModel.Id);
            return getRover;
        }


        public void SetPosition(int x, int y)
        {
            _x = x;
            _y = y;
                      
        }
        public void Process(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case ('L'):
                        TurnLeft();
                        break;
                    case ('R'):
                        TurnRight();
                        break;
                    case ('M'):
                        Move();
                        break;
                    default:
              
                        throw new ArgumentException($"Invalid value: {command}");
                }
            }
        }

        private void TurnLeft()
        {
            _facing = (_facing - 1) < N ? W : _facing - 1;
        }


        private void TurnRight()
        {
            _facing = (_facing + 1) > W ? N : _facing + 1;
        }

        private void Move()
        {
            if (_facing == N)
            {
                _y++;
            }
            else if (_facing == E)
            {
                _x++;
            }
            else if (_facing == S)
            {
                _y--;
            }
            else if (_facing == W)
            {
                _x--;
            }
        }

        public RoverModel RoverCurrentPosition(string roverid)
        {
            char dir = Char.MinValue;

            if (_facing == 1)
            {

                dir = 'N';
            }
            else if (_facing == 2)
            {
                dir = 'E';
            }
            else if (_facing == 3)
            {
                dir = 'S';
            }
            else if (_facing == 4)
            {
                dir = 'W';
            }

            RoverModel roverModel = new RoverModel
            {
                CurrentDirection = dir.ToString(),
                Id = roverid,
                CurrentX = _x,
                CurrentY = _y
            };

            return roverModel;
        }


    }
}