using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepRepository _repo;
    public VaultKeepsController(VaultKeepRepository repo)
    {
      _repo = repo;
    }

    //Create VaultKeep
    [HttpPost]
    public VaultKeep AddVaultKeep([FromBody]VaultKeep val)
    {

      VaultKeep result = _repo.AddVaultKeep(val);
      return result;
      // return Created("/api/VaultKeep/" + result.Id, result);
    }

    //Delete VaultKeep
    [HttpDelete("{id}")]
    public ActionResult<string> DeleteVaultKeep(int id)
    {
      if (_repo.DeleteVaultKeep(id))
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete!");
    }

    //Get Keeps By Vault ID
    [HttpGet("{id}")]
    public IEnumerable<Keep> Get(int id)
    {
      return _repo.GetOneVault(id);
    }
  }
}
