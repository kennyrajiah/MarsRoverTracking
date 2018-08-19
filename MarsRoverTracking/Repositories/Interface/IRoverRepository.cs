using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarsRoverTracking.Models;

namespace MarsRoverTracking.Repositories.Interface
{
    public interface IRoverRepository
    { 
        void SaveRoverInfo();
        RoverModel ReadRoverInfo(string id);
        void UpdateRoverInfo();
    }
}