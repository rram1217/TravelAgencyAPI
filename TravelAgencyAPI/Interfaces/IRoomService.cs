using TravelAgencyAPI.Models;

namespace TravelAgencyAPI.Interfaces
{
    public interface IRoomService
    {
        Task<Room> CreateRoomAsync(Room Room);
        Task<bool> UpdateRoomAsync(int id, Room Room);
        Task<bool> DeleteRoomAsync(int id);
        Task<List<Room>> GetRoomsByHotelIdAsync(int hotelId);
        Task<bool> ToggleRoomStatusAsync(int id, bool isEnabled);
        Task<List<Room>> GetAllRoomsAsync();
        Task<Room> GetRoomByIdAsync(int id);
    }
}
