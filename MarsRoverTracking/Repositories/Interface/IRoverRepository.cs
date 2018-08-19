using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarsRoverTracking.Repositories.Interface
{
    public interface IRoverRepository
    { 
        void SaveRoverInfo();
        void ReadRoverInfo();
        void UpdateRoverInfo();
    }
}