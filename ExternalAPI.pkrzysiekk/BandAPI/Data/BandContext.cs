using BandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BandAPI.Data;

public class BandContext :DbContext
{
 public BandContext(DbContextOptions<BandContext> options)  : base(options)
 {
 }
 DbSet<Band> Band { get; set; }
}