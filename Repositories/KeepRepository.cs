using System;
using System.Data;
using System.Linq;
using keepr.Models;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;
    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }


    //Add Keep
    public Keep AddKeep(Keep newKeep)
    {
      int id = 0;
      id = _db.ExecuteScalar<int>(@"
      INSERT INTO Keeps(name, description, userId, img, isPrivate, views, shares, keeps)
      VALUES (@Name, @Description, @UserId, @Img, @IsPrivate, @Views, @Shares, @Keeps)
      ", newKeep);
      if (id == 0) return null;
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
  }
}