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
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=hair_salon_test; Integrated Security=SSPI;";
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
    [Fact]
    public void Stylist_FindSylist()
    {
      Stylist newStylist = new Stylist("Jake");

      newStylist.Save();
      Stylist testStylist = Stylist.Find(newStylist.GetId());

      Assert.Equal(testStylist, newStylist);
    }
    [Fact]
    public void Stylist_UpdateStylistInDataBase()
    {
      string stylist = "Jenny";
      Stylist testStylist =  new Stylist(stylist);
      testStylist.Save();

      string newStylist = "Jen";
      testStylist.Update(newStylist);
      string result = testStylist.GetName();

      Assert.Equal(newStylist, result);
    }
    [Fact]
    public void Test_Delete()
    {
      Stylist newStylist = new Stylist("Jake");
      newStylist.Save();
      Stylist newStylist2 = new Stylist("Jen");
      newStylist2.Save();

      newStylist.Delete();
      List<Stylist> list = Stylist.GetAll();
      List<Stylist> list2 = new List<Stylist> {newStylist2};

      Assert.Equal(list, list2);
    }
  }
}
