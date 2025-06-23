using BandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BandAPI.Data;

public class BandContext : DbContext
{
 public BandContext(DbContextOptions<BandContext> options) : base(options)
 {
 }

 public void Initialize()
 {
  this.Database.EnsureCreated();
  
  var bands = new List<Band>
  {
   new Band
   {
    Name = "Linkin Park",
    Genre = "Nu Metal",
    imageURL = "https://upload.wikimedia.org/wikipedia/commons/3/30/Linkin_Park_logo.svg"
   },
   new Band
   {
    Name = "Korn",
    Genre = "Nu Metal",
    imageURL = "https://upload.wikimedia.org/wikipedia/commons/5/56/Korn_Logo.svg"
   },
   new Band
   {
    Name = "Limp Bizkit",
    Genre = "Nu Metal",
    imageURL = "https://upload.wikimedia.org/wikipedia/en/f/fc/Limpbizkit.png"
   },
   new Band
   {
    Name = "Slipknot",
    Genre = "Nu Metal",
    imageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/2/2b/Slipknot_-_Logo.svg/1280px-Slipknot_-_Logo.svg.png"
   },
   new Band
   {
    Name = "P.O.D.",
    Genre = "Nu Metal",
    imageURL = "https://upload.wikimedia.org/wikipedia/en/7/78/P.O.D._logo.svg"
   },
   new Band
   {
    Name = "Papa Roach",
    Genre = "Nu Metal",
    imageURL = "https://upload.wikimedia.org/wikipedia/commons/0/0b/Papa_Roach_logo.png"
   },
   new Band
   {
    Name = "Deftones",
    Genre = "Nu Metal",
    imageURL = "https://upload.wikimedia.org/wikipedia/en/7/7a/Deftones_-_Logo.svg"
   },
   new Band
   {
    Name = "Disturbed",
    Genre = "Nu Metal",
    imageURL = "https://upload.wikimedia.org/wikipedia/en/6/6b/Disturbed-logo.svg"
   }
  };
  var items=this.Bands.ToList();
  this.RemoveRange(items);
  this.AddRange(bands);
  this.SaveChanges();
 }


public DbSet<Band> Bands { get; set; }
}