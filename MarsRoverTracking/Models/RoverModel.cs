using System.ComponentModel.DataAnnotations;

namespace MarsRoverTracking.Models
{
    public class RoverModel
    {
       
        public string Id { get; set; }

        public string CurrentDirection { get; set; }

        public int CurrentX { get; set; }

        public int CurrentY { get; set; }
    }
}