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

    //Add Keep
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

    //Get Keep by ID
    [Authorize]
    [HttpGet("user")]
    public IEnumerable<Keep> Get()
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

    //Get All Keeps
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> GetAllKeeps()
    {
      return Ok(_repo.GetAllKeeps());
    }

    //Edit Keep by ID

    [HttpPut("{id}")]
    public ActionResult<Keep> EditKeep(int id, [FromBody] Keep value)
    {
      Keep result = _repo.EditKeep(id, value);
      if (result != null)
      {
        return Ok(result);
      }
      return NotFound();
    }

  }
}