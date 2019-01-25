using System;
using System.Collections.Generic;
using System.Linq;//what is this doing?
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsRepository _repo;
    public KeepsController(KeepsRepository repo)
    {
      _repo = repo;
    }

    //Create Keep
    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Post([FromBody]Keep val)
    {
      val.UserId = HttpContext.User.Identity.Name;
      if (val.UserId != null)
      {
        Keep result = _repo.AddKeep(val);
        return Created("/api/keeps" + result.Id, result);
      }
      return Unauthorized("Login to create keep!!!!");
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

    //Get User Keeps
    [Authorize]
    [HttpGet("user")]
    public IEnumerable<Keep> GetKeeps()
    {
      string uid = HttpContext.User.Identity.Name;
      return _repo.GetKeepByUserId(uid);
      // Keep result = _repo.GetKeepById(id);
      // if (result != null)
      // {
      //   return Ok(result);
      // }
      // return BadRequest();

    }
    [HttpGet]

    //Get Public Keeps
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> GetAllKeeps()
    {
      return Ok(_repo.GetAllKeeps());
    }

    //Edit Keep by ID

    [HttpPut]
    public ActionResult<string> EditKeep([FromBody] Keep value)
    {
      int result = _repo.EditKeep(value);
      if (result == 1)
      {
        return Ok("success");
      }
      return BadRequest("Unsuccessful edit");
    }

  }
}