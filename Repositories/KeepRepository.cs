using System;
using System.Data;
using System.Linq;
using Keepr.Models;
using Dapper;
using System.Collections.Generic;
// using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }


    //Add Keep
    public Keep AddKeep(Keep newKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO Keeps(name, description, UserId, img, isPrivate)
      VALUES (@Name, @Description, @UserId, @Img, @IsPrivate);
      SELECT LAST_INSERT_ID();
      ", newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    //Delete Keep
    public bool DeleteKeep(int id)
    {
      int success = _db.Execute(@"
      DELETE FROM Keeps WHERE id = @id
      ", new { id });
      return success != 0;
    }

    //Get User Keeps
    public IEnumerable<Keep> GetKeepByUserId(string id)
    {
      return _db.Query<Keep>($"SELECT * FROM Keeps WHERE userid = @id", new { id });
    }


    //Edit Keep
    public int EditKeep(Keep newkeep)
    {
      try
      {
        //runs changes on table and in this case it will return a keep
        return _db.Execute($@"
          UPDATE Keeps SET
            views = @Views,
            shares = @Shares,
            keeps=@Keeps
          WHERE id = @Id;
        ", newkeep);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return 0;
      }
    }

    //Get Public Keeps
    public IEnumerable<Keep> GetAllKeeps()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = false");
    }
  }
}