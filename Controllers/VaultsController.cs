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
  public class VaultsController : ControllerBase
  {
    private readonly VaultsRepository _repo;
    public VaultsController(VaultsRepository repo)
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

    //Delete Vaults


    [HttpDelete("{id}")]
    public ActionResult<string> DeleteVault(int id)
    {
      if (_repo.DeleteVault(id))
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete!");
    }


    //Get User Vaults(Get Vaults for the logged in user)

    [HttpGet]
    public IEnumerable<Vault> GetVault()
    {
      string uid = HttpContext.User.Identity.Name;
      return _repo.GetVaultById(uid);

    }


    //Edit Vault


    [HttpPut("{id}")]
    public ActionResult<Vault> EditVault(int id, [FromBody] Vault value)
    {

      value.Id = id;

      Vault result = _repo.EditVault(id, value);
      if (result != null)
      {
        return Ok(result);
      }
      return NotFound();
    }

    //Get Vault
    [HttpGet("{id}")]
    public ActionResult<Vault> GetVault(int id)
    {
      Vault result = _repo.GetOneVault(id);
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

