using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace HairSalon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=DESKTOP-86RQO71; Initial Catalog=hair_salon_test; Integrated Security=SSPI;";
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }

    [Fact]
    public void Client_DataBaseEmptyAtFirst()
    {
      int result = Client.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Client_SaveToDataBase()
    {
      Client testClient = new Client("Dave", 1);
      testClient.Save();

      int result = Client.GetAll().Count;

      Assert.Equal(1, result);
    }

    [Fact]
    public void Client_IdPassesCorrectly()
    {
      Client testClient = new Client("Dave", 1);
      int result = testClient.GetId();
      Assert.Equal(0, result);
    }

    [Fact]
    public void Client_Find()
    {
      Client newClient = new Client("Dave", 2);
      newClient.Save();
      Client testClient = Client.Find(newClient.GetId());
      Console.WriteLine("Find: " + newClient.GetId() + " " + testClient.GetId());
      Assert.Equal(testClient, newClient);
    }


  }
}
