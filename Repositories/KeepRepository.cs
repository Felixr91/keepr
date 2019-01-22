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
      INSERT INTO Keeps(name, description, userId, img, isPrivate)
      VALUES (@Name, @Description, @UserId, @Img, @IsPrivate)
      ", newKeep);
      newKeep.Id = id;
      return newKeep;
      // {
      //   Name = newKeep.Name,
      //   Description = newKeep.Description,
      //   UserId = newKeep.UserId,
      //   Img = newKeep.Img,
      //   IsPrivate = newKeep.IsPrivate,
      //   Views = newKeep.Views,
      //   Shares = newKeep.Shares,
      //   Keeps = newKeep.Keeps
      // };
    }

    //Delete Keep
    public bool DeleteKeep(int id)
    {
      int success = _db.Execute(@"
      DELETE FROM Keeps WHERE id = @id
      ", new { id });
      return success != 0;
    }

    //Get Keep by ID
    public IEnumerable<Keep> GetKeepByUserId(string id)
    {
      return _db.Query<Keep>($"SELECT * FROM Keeps WHERE userId = @id", new { id });
    }

    //Edit Keep
    public Keep EditKeep(int id, Keep newkeep)
    {
      try
      {
        return _db.QueryFirstOrDefault<Keep>($@"
          UPDATE Keeps SET
            Views = @Views,
            Shares = @Shares,
            Keeps=@Keeps
          WHERE Id = @Id;
          SELECT * FROM Keeps WHERE id = @Id;
        ", newkeep);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }

    //Get all keeps
    public IEnumerable<Keep> GetAllKeeps()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = false");
    }
  }
}