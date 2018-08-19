
using System.ComponentModel.DataAnnotations;
using MarsRoverTracking.Utilities;

namespace MarsRoverTracking.Models
{
    public class RoverUpdateModel
    {
        [Required]
        [StringLength(10, MinimumLength = 0, ErrorMessage = "Too many characters")]
        public string Id { get; set; }

        [Required]
        [ValidValues("LRM")]
        [StringLength(10, MinimumLength = 0, ErrorMessage = "Too many characters")]
        public string MovementInstruction { get; set; }

    }
}
