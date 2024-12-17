using TravelAgencyAPI.Models;
using TravelAgencyAPI.Data;
using TravelAgencyAPI.Interfaces;

namespace TravelAgencyAPI.Services
{
    public class GuestService : IGuestService
    {
        private readonly TravelAgencyContext _dbContext;

        public GuestService(TravelAgencyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guest> CreateGuestAsync(Guest guest)
        {
            await _dbContext.Guests.AddAsync(guest);
            await _dbContext.SaveChangesAsync();
            return guest;
        }

        public Task<bool> DeleteGuestAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Guest>> GetAllGuestsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            return await _dbContext.Guests.FindAsync(id);
        }

        public Task<Guest> UpdateGuestAsync(int id, Guest Guest)
        {
            throw new NotImplementedException();
        }
    }
}
