using System.ComponentModel.DataAnnotations;

namespace TravelAgencyAPI.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; } // Identificador único del hotel

        [Required(ErrorMessage = "El nombre del Hotel es obligatorio.")]
        [MaxLength(200)]
        public required string Name { get; set; } // Nombre del hotel

        [Required(ErrorMessage = "La Dirección del hotel es obligatoria.")]
        [MaxLength(500)]
        public required string Address { get; set; } // Dirección del hotel

        [Required(ErrorMessage = "La Ciudad donde está ubicado el hotel es obligatoria.")]
        [MaxLength(100)]
        public required string City { get; set; } // Ciudad donde está ubicado el hotel

        [Required(ErrorMessage = "El País donde está ubicado el hotel es obligatorio.")]
        [MaxLength(100)]
        public required string Country { get; set; } // País donde está ubicado el hotel

        [Phone(ErrorMessage = "El Teléfono de contacto del hotel debe ser un numero valido.")]
        public string Phone { get; set; } // Teléfono de contacto del hotel

        [EmailAddress(ErrorMessage = "El Correo electrónico de contacto del hotel debe contener un formato valido. (email@email.com)")]
        public string Email { get; set; } // Correo electrónico de contacto del hotel

        public int StarRating { get; set; } // Calificación del hotel (de 1 a 5 estrellas)

        public bool IsEnabled { get; set; } = true; // Indica si el hotel está habilitado o deshabilitado

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Fecha de creación del hotel

        public DateTime? UpdatedAt { get; set; } // Fecha de última modificación del hotel

        // Relación con el modelo Room
        //public virtual ICollection<Room> Rooms { get; set; } // Lista de habitaciones del hotel
    }
}
