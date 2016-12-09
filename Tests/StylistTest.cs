using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace HairSalon
{
  public class stylistTest : IDisposable
  {
    public stylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=DESKTOP-86RQO71; Initial Catalog=hair_salon_test; Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
    [Fact]
    public void Stylist_DataBaseEmptyAtFirst()
    {
      int result = Stylist.GetAll().Count;

      Assert.Equal(0, result);
    }
    [Fact]
    public void Stylist_SaveStylistToDataBase()
    {
      Stylist testStylist = new Stylist("Jake");
      testStylist.Save();

      int result = Stylist.GetAll().Count;

      Assert.Equal(1, result);
    }
    [Fact]
    public void Stylist_ReturnsTrueForSameStylist()
    {
      Stylist firstStylist = new Stylist("Jake");
      Stylist secondStylist = new Stylist("Jake");
      Assert.Equal(firstStylist, secondStylist);
    }
    [Fact]
    public void Stylist_IdPassesCorrectly()
    {
      Stylist testStylist = new Stylist("Jake");
      int result = testStylist.GetId();
      Assert.Equal(0, result);
    }
  }
}
