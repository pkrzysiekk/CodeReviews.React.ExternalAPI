using BandAPI.Data;
using BandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BandAPI.Repository;

public class BandRepository : IBandRepository
{
    private BandContext _context;
    public BandRepository(BandContext context)
    {
      _context=context;   
    }
    public async Task AddBand(Band band)
    {
        _context.Add(band);
        await _context.SaveChangesAsync();
    }

    public async Task<Band?> GetBandById(int id)
    {
        var band = _context.Bands.FirstOrDefault(b => b.Id == id);
        if (band != null) return band;
        return null;
    }

    public async Task UpdateBand(Band band)
    {
        var existing = await GetBandById(band.Id);
        if (existing != null)
        {
            existing.Name = band.Name;
            existing.Genre = band.Genre;
            existing.imageURL = band.imageURL;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteBand(Band band)
    {
        var b = await GetBandById(band.Id);
        if (b != null) b = band;
       _context.Bands.Remove(b);   
       await _context.SaveChangesAsync();
    }

    public async Task<List<Band>> GetBands()
    {
        var bands =  await _context.Bands.ToListAsync();
        return bands;
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}