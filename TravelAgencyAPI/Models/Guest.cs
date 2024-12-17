using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelAgencyAPI.Models;

namespace TravelAgencyAPI.Models
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; } // Identificador único del huésped

        [Required(ErrorMessage = "El Nombre completo del huésped es obligatorio.")]
        [MaxLength(100)]
        public required string FullName { get; set; } // Nombre completo del huésped

        [Required(ErrorMessage = "La Fecha de nacimiento del huésped es obligatorio.")]
        public DateTime BirthDate { get; set; } // Fecha de nacimiento del huésped

        [Required(ErrorMessage = "El Género del huésped (Male/Female/Other) es obligatorio.")]
        [MaxLength(10)]
        public required string Gender { get; set; } // Género del huésped (Male/Female/Other)

        [Required(ErrorMessage = "El Tipo de documento (Pasaporte, DNI, etc.) del huésped es obligatorio.")]
        [MaxLength(20)]
        public required string DocumentType { get; set; } // Tipo de documento (Pasaporte, DNI, etc.)

        [Required(ErrorMessage = "El Número del documento del huésped es obligatorio.")]
        [MaxLength(20)]
        public required string DocumentNumber { get; set; } // Número del documento

        [Required(ErrorMessage = "El Email del huésped es obligatorio.")]
        [EmailAddress]
        public required string Email { get; set; } // Email del huésped

        [Required(ErrorMessage = "El Teléfono de contacto del huésped es obligatorio.")]
        [Phone]
        public required string Phone { get; set; } // Teléfono de contacto del huésped

        // Relación con la tabla Reservation
        //public virtual Reservation Reservation { get; set; }
    }
}
