using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LiteDB;
using MarsRoverTracking.Models;
using MarsRoverTracking.Repositories.Interface;

namespace MarsRoverTracking.Repositories.Implementation
{
    public class RoverRepository:IRoverRepository
    {
        public static readonly string Connection = "Filename=rover.litedb4; Mode=Exclusive;";

        public void SaveRoverInfo()
        {
           
        }

        public RoverModel ReadRoverInfo(string id)
        {
            RoverModel resultModel;
            using (var db = new LiteDatabase(Connection))
            {
                var collection = db.GetCollection<RoverModel>("roverModel");

                collection.EnsureIndex(x => x.Name);

                 resultModel = collection.Find(x => x.Id == "1").FirstOrDefault();


            }
            return resultModel;
        }

        public void UpdateRoverInfo()
        {
           
        }

    }
}