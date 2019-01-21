using System;
using System.Data;
using System.Linq;
using Keepr.Models;
using Dapper;
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
      _db.ExecuteScalar<int>(@"
      INSERT INTO Keeps(name, description, userId, img, isPrivate, views, shares, keeps)
      VALUES (@Name, @Description, @UserId, @Img, @IsPrivate, @Views, @Shares, @Keeps)
      ", newKeep);
      return new Keep()
      {
        Name = newKeep.Name,
        Description = newKeep.Description,
        UserId = newKeep.UserId,
        Img = newKeep.Img,
        IsPrivate = newKeep.IsPrivate,
        Views = newKeep.Views,
        Shares = newKeep.Shares,
        Keeps = newKeep.Keeps
      };
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
    public Keep GetKeepById(int id)
    {
      return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM Keeps WHERE id = @id", new { id });
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
  }
}