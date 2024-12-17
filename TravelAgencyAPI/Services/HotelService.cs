using Microsoft.EntityFrameworkCore;
using TravelAgencyAPI.Data;
using TravelAgencyAPI.Interfaces;
using TravelAgencyAPI.Models;

public class HotelService : IHotelService
{
    private readonly TravelAgencyContext _context;

    public HotelService(TravelAgencyContext context)
    {
        _context = context;
    }

    public async Task<Hotel> CreateHotelAsync(Hotel Hotel)
    {
        var hotel = new Hotel
        {
            Name = Hotel.Name,
            Address = Hotel.Address,
            City = Hotel.City,
            Country = Hotel.Country,
            IsEnabled = true // Por defecto, habilitado
        };

        _context.Hotels.Add(hotel);
        await _context.SaveChangesAsync();

        Hotel.HotelId = hotel.HotelId;
        return Hotel;
    }

    public async Task<Hotel> UpdateHotelAsync(int id, Hotel Hotel)
    {
        var hotel = await _context.Hotels.FindAsync(id);
        if (hotel == null)
            throw new KeyNotFoundException("Hotel not found");

        hotel.Name = Hotel.Name;
        hotel.Address = Hotel.Address;
        hotel.City = Hotel.City;
        hotel.Country = Hotel.Country;
        hotel.UpdatedAt = DateTime.Now;

        _context.Hotels.Update(hotel);
        await _context.SaveChangesAsync();

        return Hotel;
    }

    public async Task<bool> DeleteHotelAsync(int id)
    {
        var hotel = await _context.Hotels.FindAsync(id);
        if (hotel == null)
            throw new KeyNotFoundException("Hotel not found");

        _context.Hotels.Remove(hotel);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<Hotel>> GetAllHotelsAsync()
    {
        return await _context.Hotels
            .Select(h => new Hotel
            {
                HotelId = h.HotelId,
                Name = h.Name,
                Address = h.Address,
                City = h.City,
                Country = h.Country,
                IsEnabled = h.IsEnabled
            })
            .ToListAsync();
    }

    public async Task<Hotel> GetHotelByIdAsync(int id)
    {
        var hotel = await _context.Hotels.FindAsync(id);
        if (hotel == null)
            throw new KeyNotFoundException("Hotel not found");

        return new Hotel
        {
            HotelId = hotel.HotelId,
            Name = hotel.Name,
            Address = hotel.Address,
            City = hotel.City,
            Country = hotel.Country,
            IsEnabled = hotel.IsEnabled
        };
    }

    public async Task<bool> ToggleHotelStatusAsync(int id, bool isEnabled)
    {
        var hotel = await _context.Hotels.FindAsync(id);
        if (hotel == null)
            throw new KeyNotFoundException("Hotel not found");

        hotel.IsEnabled = isEnabled;
        _context.Hotels.Update(hotel);
        await _context.SaveChangesAsync();

        return true;
    }
}
