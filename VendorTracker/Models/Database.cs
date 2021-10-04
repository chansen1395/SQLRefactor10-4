using System;
using MySql.Data.MySqlClient;
using VendorTracker;

namespace VendorTracker.Models
{
  public class DB
  {
    public static MySqlConnection Connection()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }
  }
}