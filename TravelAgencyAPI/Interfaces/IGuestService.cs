using TravelAgencyAPI.Models;

namespace TravelAgencyAPI.Interfaces
{
    public interface IGuestService
    {
        Task<Guest> CreateGuestAsync(Guest Guest);
        Task<Guest> UpdateGuestAsync(int id, Guest Guest);
        Task<bool> DeleteGuestAsync(int id);
        Task<List<Guest>> GetAllGuestsAsync();
        Task<Guest> GetGuestByIdAsync(int id);
    }
}
