using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;
    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }


    //Add Vault
    public Vault AddVault(VaultToCreate newVault)
    {
      int id = 0;
      id = _db.ExecuteScalar<int>(@"
      INSERT INTO Vaults(name, description, userId)
      VALUES (@Name, @Description, @UserId);
      SELECT LAST_INSERT_ID();
      ", newVault);
      //safety check
      if (id == 0) return null;
      return new Vault()
      {
        Name = newVault.Name,
        Description = newVault.Description,
        UserId = newVault.UserId,
        Id = id
      };
    }

    public bool DeleteVault(int id)
    {
      int success = _db.Execute(@"
      DELETE FROM Vaults WHERE id = @id
      ", new { id });
      return success != 0;
    }

    //GetById

    public Vault GetVaultById(int id)
    {
      return _db.QueryFirstOrDefault<Vault>($"SELECT * FROM Vaults WHERE id = @id", new { id });
    }

    //Edit vault

    public Vault EditVault(int id, Vault newvault)
    {
      try
      {
        return _db.QueryFirstOrDefault<Vault>($@"
          UPDATE Vaults SET
            Name = @Name,
            Description = @Description,
            UserId = @UserId
          WHERE Id = @Id;
          SELECT * FROM Vaults WHERE id = @Id;
        ", newvault);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }

  }

}