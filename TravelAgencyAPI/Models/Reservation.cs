using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgencyAPI.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; } // Identificador único de la reserva

        [Required(ErrorMessage = "El ID de la habitacion es es obligatorio.")]
        [ForeignKey("Room")]
        public int RoomId { get; set; } // Llave foránea que referencia la habitación reservada

        [Required(ErrorMessage = "La Fecha de entrada al hotel es obligatoria.")]
        public DateTime CheckInDate { get; set; } // Fecha de entrada al hotel

        [Required(ErrorMessage = "La Fecha de salida del hotel es obligatoria.")]
        public DateTime CheckOutDate { get; set; } // Fecha de salida del hotel

        [Required(ErrorMessage = "La Cantidad de personas en la reserva es obligatoria.")]
        public int NumberOfGuests { get; set; } // Cantidad de personas en la reserva

        public decimal TotalPrice { get; set; } // Precio total de la reserva

        public bool IsConfirmed { get; set; } = false; // Estado de confirmación de la reserva

        // Contacto de emergencia
        [Required(ErrorMessage = "El Nombre del contacto de emergencia es obligatorio.")]
        [MaxLength(100)]
        public string EmergencyContactName { get; set; } // Nombre del contacto de emergencia

        [Required(ErrorMessage = "El Teléfono del contacto de emergencia es obligatorio.")]
        [Phone(ErrorMessage = "El Teléfono de contacto debe ser un numero valido.")]
        public string EmergencyContactPhone { get; set; } // Teléfono del contacto de emergencia

        // Relación con la tabla Room
        //public virtual Room Room { get; set; }

        [Required(ErrorMessage = "El Id del huésped es obligatorio.")]
        [ForeignKey("Guest")]
        public int GuestId { get; set; } // ID de el huesped

        [Required(ErrorMessage = "La Fecha de creacion de la reservacion es obligatoria.")]
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Fecha de creacion de la reservacion
    }
}
