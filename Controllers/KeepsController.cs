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
  public class KeepsControlller : ControllerBase
  {
    private readonly KeepsRepository _repo;
    public KeepsControlller(KeepsRepository repo)
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

    //Delete Keep
    [HttpDelete("{id}")]
    public ActionResult<string> DeleteKeep(int id)
    {
      if (_repo.DeleteKeep(id))
      {
        return Ok("Successfully Deleted!");
      }
      return BadRequest("Unable to delete!");
    }
  }
}