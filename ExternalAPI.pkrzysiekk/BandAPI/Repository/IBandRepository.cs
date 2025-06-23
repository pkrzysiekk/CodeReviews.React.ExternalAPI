using BandAPI.Models;

namespace BandAPI.Repository;

public interface IBandRepository
{
    public Task AddBand(Band band);
    public Task<Band?> GetBandById(int id);
    public Task UpdateBand(Band band);
    public Task DeleteBand(Band band);
    public Task<List<Band>> GetBands();
    public Task SaveChanges();
}