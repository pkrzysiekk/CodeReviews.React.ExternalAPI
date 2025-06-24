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
    imageURL = "https://w0.peakpx.com/wallpaper/215/379/HD-wallpaper-linkin-park-linkinparklogo.jpg"
   },
   new Band
   {
    Name = "Korn",
    Genre = "Nu Metal",
    imageURL = "https://1000marcas.net/wp-content/uploads/2020/02/Logo-Korn-768x480.png"
   },
   new Band
   {
    Name = "Limp Bizkit",
    Genre = "Nu Metal",
    imageURL = "https://1000logos.net/wp-content/uploads/2020/04/Limp-Bizkit-Logo.png"
   },
   new Band
   {
    Name = "Slipknot",
    Genre = "Nu Metal",
    imageURL ="https://wallpaperaccess.com/full/1617294.jpg"
   },
   new Band
   {
    Name = "P.O.D.",
    Genre = "Nu Metal",
    imageURL = "https://logodix.com/logo/2086957.png"
   },
   new Band
   {
    Name = "Papa Roach",
    Genre = "Nu Metal",
    imageURL = "https://logodix.com/logo/748862.jpg"
   },
   new Band
   {
    Name = "Deftones",
    Genre = "Nu Metal",
    imageURL = "https://logodix.com/logo/2094590.jpg"
   },
   new Band
   {
    Name = "Disturbed",
    Genre = "Nu Metal",
    imageURL = "https://1000logos.net/wp-content/uploads/2017/09/Emblem-Disturbed-768x644.jpg"
   }
  };
  var items=this.Bands.ToList();
  this.RemoveRange(items);
  this.AddRange(bands);
  this.SaveChanges();
 }


public DbSet<Band> Bands { get; set; }
}