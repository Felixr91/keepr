using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller")]
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

  }
}