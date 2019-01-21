using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;
    }

    //Add Keeps to Vault
    public VaultKeep AddVaultKeep(VaultKeep vk)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO VaultKeep(VaultId, KeepId)
      VALUES (@VaultId, @KeepId);
      SELECT LAST_INSERT_ID();
      ", vk);
      vk.Id = id;
      return vk;
    }

    // Delete VaultKeep

    public bool DeleteVaultKeep(VaultKeep vk)
    {
      int success = _db.Execute(@"
      DELETE FROM VaultKeeps WHERE KeepId = @KeepId AND
      LibraryId = @LibraryId
      ", vk);
      return success != 0;
    }
  }
}
