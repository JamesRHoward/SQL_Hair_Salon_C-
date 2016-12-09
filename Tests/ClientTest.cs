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
  }
}
