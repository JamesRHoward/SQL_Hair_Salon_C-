using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class Client
  {
    private int _id;
    private string _name;
    private int _stylist_id;

    public Client(string Name, int StylistId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _stylist_id = StylistId;
    }

    public void SetId(int Id)
    {
      _id = Id;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetName(string Name)
    {
      _name = Name;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetStylistId(int StylistId)
    {
      _stylist_id = StylistId;
    }

    public int GetStylistId()
    {
      return _stylist_id;
    }
    public override bool Equals(System.Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = this.GetId() == newClient.GetId();
        bool nameEquality = this.GetName() == newClient.GetName();

        return(idEquality && nameEquality);
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      if(conn!=null)
      {
        conn.Close();
      }
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client>{};
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        int clientStylistId = rdr.GetInt32(2);
        Client newClient = new Client(clientName, clientStylistId, clientId);
        allClients.Add(newClient);
      }
      if(rdr!=null)
      {
        rdr.Close();
      }
      if(conn!=null)
      {
        conn.Close();
      }
      return allClients;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, stylistid) OUTPUT INSERTED.id VALUES (@ClientName, @ClientStylistId);", conn);

      SqlParameter clientNameParameter = new SqlParameter();
      clientNameParameter.ParameterName = "@ClientName";
      clientNameParameter.Value = this.GetName();
      cmd.Parameters.Add(clientNameParameter);

      SqlParameter clientStylistIdParameter = new SqlParameter();
      clientStylistIdParameter.ParameterName = "@ClientStylistId";
      clientStylistIdParameter.Value = this.GetStylistId();
      cmd.Parameters.Add(clientStylistIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if(rdr!=null)
      {
        rdr.Close();
      }
      if(conn!=null)
      {
        conn.Close();
      }
    }

    public static Client Find(int Id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientId;", conn);
      SqlParameter clientIdParameter = new SqlParameter();
      clientIdParameter.ParameterName = "@ClientId";
      clientIdParameter.Value = Id.ToString();
      cmd.Parameters.Add(clientIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundClientId = 0;
      string foundClientName = null;
      int foundStylistId = 0;

      while(rdr.Read())
      {
        foundClientId = rdr.GetInt32(0);
        foundClientName = rdr.GetString(1);
        foundStylistId = rdr.GetInt32(2);
      }
      Client foundClient = new Client(foundClientName, foundStylistId, foundClientId);

      if(rdr!=null)
      {
        rdr.Close();
      }
      if(conn!=null)
      {
        conn.Close();
      }
      return foundClient;
    }

    public void Update(string newName, int newStylistId)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE clients SET name = @NewName OUTPUT INSERTED.name WHERE id = @ClientId; UPDATE clients SET stylistId = @NewStylistId OUTPUT INSERTED.stylistId WHERE id = @ClientId;", conn);

      SqlParameter newNameParameter = new SqlParameter();
      newNameParameter.ParameterName = "@NewName";
      newNameParameter.Value = newName;
      cmd.Parameters.Add(newNameParameter);

      SqlParameter NewStylistIdParameter = new SqlParameter();
      NewStylistIdParameter.ParameterName = "@NewStylistId";
      NewStylistIdParameter.Value = newStylistId;
      cmd.Parameters.Add(NewStylistIdParameter);


      SqlParameter clientIdParameter = new SqlParameter();
      clientIdParameter.ParameterName = "@ClientId";
      clientIdParameter.Value = this.GetId();
      cmd.Parameters.Add(clientIdParameter);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._name = rdr.GetString(0);
      }

      if (rdr != null)
      {
        rdr.Close();
      }

      if (conn != null)
      {
        conn.Close();
      }
    }


  }
}
