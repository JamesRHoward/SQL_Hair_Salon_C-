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
      DBConfiguration.ConnectionString = "Data Source=(86QO71)\\James(54); Initial Catalog=hair_salon_test; Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
