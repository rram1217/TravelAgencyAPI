using TravelAgencyAPI.Models;

namespace TravelAgencyAPI.Interfaces
{
    public interface IHotelService
    {
        Task<Hotel> CreateHotelAsync(Hotel Hotel);
        Task<Hotel> UpdateHotelAsync(int id, Hotel Hotel);
        Task<bool> DeleteHotelAsync(int id);
        Task<List<Hotel>> GetAllHotelsAsync();
        Task<Hotel> GetHotelByIdAsync(int id);
        Task<bool> ToggleHotelStatusAsync(int id, bool isEnabled);
    }
}
