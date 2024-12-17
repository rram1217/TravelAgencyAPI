using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgencyAPI.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "La descripcion de la habitacion es es obligatorio.")]
        public required string Description { get; set; }

        public decimal Price { get; set; }

        public int Capacity { get; set; }

        public bool IsEnabled { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Relationship with Hotel
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        //public virtual Hotel Hotel { get; set; }
    }
}
