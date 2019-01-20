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
  public class KeepControlller : ControllerBase
  {
    private readonly KeepRepository _repo;
    public KeepControlller(KeepRepository repo)
    {
      _repo = repo;
    }
    //Create Keep
    [HttpPost]
    public Keep AddKeep([FromBody]Keep val)
    {
      val.UserId = HttpContext.User.Identity.Name;
      return _repo.AddKeep(val);
    }
  }
}