using TravelAgencyAPI.Models;
using TravelAgencyAPI.Data;
using Microsoft.EntityFrameworkCore;
using TravelAgencyAPI.Interfaces;

namespace TravelAgencyAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly TravelAgencyContext _dbContext;

        public RoomService(TravelAgencyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Room> CreateRoomAsync(Room room)
        {
            await _dbContext.Rooms.AddAsync(room);
            await _dbContext.SaveChangesAsync();
            return room;
        }

        public async Task<List<Room>> GetAllRoomsAsync()
        {
            return await _dbContext.Rooms.ToListAsync();
        }

        public async Task<Room> GetRoomByIdAsync(int id)
        {
            return await _dbContext.Rooms.FindAsync(id);
        }

        public async Task<bool> UpdateRoomAsync(int id, Room updatedRoom)
        {
            var room = await _dbContext.Rooms.FindAsync(id);
            if (room == null) return false;

            room.Description = updatedRoom.Description;
            room.Capacity = updatedRoom.Capacity;
            room.Price = updatedRoom.Price;
            room.IsEnabled = updatedRoom.IsEnabled;

            _dbContext.Rooms.Update(room);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRoomAsync(int id)
        {
            var room = await _dbContext.Rooms.FindAsync(id);
            if (room == null) return false;

            _dbContext.Rooms.Remove(room);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public Task<List<Room>> GetRoomsByHotelIdAsync(int hotelId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ToggleRoomStatusAsync(int id, bool isEnabled)
        {
            throw new NotImplementedException();
        }
    }
}
