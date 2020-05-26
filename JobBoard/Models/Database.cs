using System;
using MySql.Data.MySqlClient;
using JobBoard;

namespace JobBoard.Models
{
  public class DB
  {
    public static MysqlConnection Connection()
    {
      MysqlConnection conn = new MysqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }
  }
}