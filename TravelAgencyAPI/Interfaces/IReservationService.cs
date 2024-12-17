using TravelAgencyAPI.Models;

namespace TravelAgencyAPI.Interfaces
{
    public interface IReservationService
    {
        Task<Reservation> CreateReservationAsync(Reservation Reservation);
        Task<bool> UpdateReservationAsync(int id, Reservation Reservation);
        Task<bool> DeleteReservationAsync(int id);
        Task<List<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int id);
    }
}
