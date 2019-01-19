using System;
using System.Collections.Generic;
using System.Linq;//what is this doing?
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultController : ControllerBase
  {
    private readonly VaultRepository _repo;
    public VaultController(VaultRepository repo)
    {
      _repo = repo;
    }

    //Create Vault
    [HttpPost]
    public Vault AddVault([FromBody] VaultToCreate val)
    {
      val.UserId = HttpContext.User.Identity.Name;
      return _repo.AddVault(val);
      //return ok()
    }

    [HttpDelete("{id}")]
    public ActionResult<string> DeleteVault(int id)
    {
      if (_repo.DeleteVault(id))
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete!");
    }


    // GET by ID
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      Vault result = _repo.GetVaultById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }





  }
}










//Post Vault ([FromBody] VaultToCreate rawVault) {
// rawVault.UserId = HttpContext.etc...

