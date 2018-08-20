using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiteDB;
using MarsRoverTracking.Models;
using MarsRoverTracking.Repositories.Interface;

namespace MarsRoverTracking.Repositories.Implementation
{
    
    public class RoverRepository:IRoverRepository
    {
        public static readonly string Connection = "Filename=rover.litedb4; Mode=Exclusive;";

        public RoverModel CreateRoverInfo(string id)
        {
            using (var db = new LiteDatabase(Connection))
            {
                var collection = db.GetCollection<RoverModel>("roverModel");
                var rover = new RoverModel
                {          
                    Id = id,
                    CurrentX = 0,
                    CurrentY = 0,
                    CurrentDirection = "N"
                };
                collection.Insert(rover);
                return rover;
            }
           
        }

        public RoverModel ReadRoverInfo(string id)
        {
            RoverModel resultModel;
            using (var db = new LiteDatabase(Connection))
            {
                var collection = db.GetCollection<RoverModel>("roverModel");
                 resultModel = collection.Find(x => x.Id == id).FirstOrDefault();
            }

            return resultModel;
        }

        public RoverModel UpdateRoverInfo(RoverModel roverModel)
        {
           
            using (var db = new LiteDatabase(Connection))
            {
                var collection = db.GetCollection<RoverModel>("roverModel");
                collection.Update(roverModel);
                var resultModel = collection.Find(x => x.Id == roverModel.Id).FirstOrDefault();

                return resultModel;
            }
        }

    }
}