using TravelAgencyAPI.Models;
using TravelAgencyAPI.Data;
using Microsoft.EntityFrameworkCore;
using TravelAgencyAPI.Interfaces;

namespace TravelAgencyAPI.Services
{
    public class ReservationService : IReservationService
    {
        private readonly TravelAgencyContext _dbContext;

        public ReservationService(TravelAgencyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            await _dbContext.Reservations.AddAsync(reservation);
            await _dbContext.SaveChangesAsync();
            return reservation;
        }

        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            return await _dbContext.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _dbContext.Reservations.FindAsync(id);
        }

        public async Task<bool> UpdateReservationAsync(int id, Reservation updatedReservation)
        {
            var reservation = await _dbContext.Reservations.FindAsync(id);
            if (reservation == null) return false;

            reservation.CheckInDate = updatedReservation.CheckInDate;
            reservation.CheckOutDate = updatedReservation.CheckOutDate;
            reservation.NumberOfGuests = updatedReservation.NumberOfGuests;
            reservation.EmergencyContactName = updatedReservation.EmergencyContactName;
            reservation.EmergencyContactPhone = updatedReservation.EmergencyContactPhone;

            _dbContext.Reservations.Update(reservation);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteReservationAsync(int id)
        {
            var reservation = await _dbContext.Reservations.FindAsync(id);
            if (reservation == null) return false;

            _dbContext.Reservations.Remove(reservation);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
