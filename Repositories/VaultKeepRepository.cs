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
      INSERT INTO VaultKeeps(UserId, VaultId, KeepId)
      VALUES (@UserId, @VaultId, @KeepId);
      SELECT LAST_INSERT_ID();
      ", vk);
      vk.Id = id;
      return vk;
    }

    // Delete VaultKeep
    public bool DeleteVaultKeep(int id)
    {
      int success = _db.Execute(@"
      DELETE FROM VaultKeeps WHERE (id = @id);
      ", new { id });
      return success != 0;
    }

    //Get Keeps by Vault ID
    public IEnumerable<Keep> GetOneVault(int id)
    {
      return _db.Query<Keep>(@"
        SELECT * FROM vaultkeeps vk
        INNER JOIN keeps k ON k.id = vk.keepId 
        WHERE (vaultId = @Id); 
      ", new { id });
    }
  }
}
