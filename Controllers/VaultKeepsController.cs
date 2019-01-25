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
    public ActionResult AddVaultKeep([FromBody]VaultKeep val)
    {
      val.UserId = HttpContext.User.Identity.Name;
      VaultKeep result = _repo.AddVaultKeep(val);
      return Ok();
      // return Created("/api/VaultKeep/" + result.Id, result);
    }

    //Delete VaultKeep
    [HttpPut]
    public ActionResult<string> DeleteVaultKeep([FromBody] VaultKeep vaultkeep)
    {
      var result = _repo.DeleteVaultKeep(vaultkeep);
      if (result != false)
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
