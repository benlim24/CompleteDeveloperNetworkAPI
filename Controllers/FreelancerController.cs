using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompleteDeveloperNetworkAPI.Models;
using CompleteDeveloperNetworkAPI.Data;
using System.Collections.Generic;
using System.Linq;
using CompleteDeveloperNetworkAPI.Migrations;
using Microsoft.EntityFrameworkCore;

namespace CompleteDeveloperNetworkAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FreelancerController : ControllerBase
  {
    private readonly APIContext _context;

    public FreelancerController(APIContext context)
    {
      _context = context;
    }

    // Create/Edit
    [HttpPost]
    public ActionResult<Freelancer> CreateEdit(Freelancer freelancer)
    {
      if(freelancer.Id == 0)
      {
          _context.FreelancerInfo.Add(freelancer);
      }
      else
      {
        var freelancerInDb = _context.FreelancerInfo.Find(freelancer.Id);

        if(freelancerInDb == null)
          return NotFound();

        _context.Entry(freelancerInDb).CurrentValues.SetValues(freelancer);
      }

      try
      {
        _context.SaveChanges();
      }
      catch (DbUpdateException ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to add/edit freelancer", exception = ex.Message});
      }

      return freelancer;
    }

    // Get
    [HttpGet("{id}")]
    public ActionResult<Freelancer> Get(int id)
    {
      var result = _context.FreelancerInfo.Find(id);

      if (result == null)
        return NotFound();

      return result;
    }

    // Delete
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var result = _context.FreelancerInfo.Find(id);

      if (result == null)
        return NotFound();

      _context.FreelancerInfo.Remove(result);

      try
      {
        _context.SaveChanges();
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to delete freelancer", exception = ex.Message });
      }

      return NoContent();
    }

    // Get All
    [HttpGet("GetAll")]
    public ActionResult<IEnumerable<Freelancer>> GetAll()
    {
      var result = _context.FreelancerInfo.ToList();

      return result;
    }
  }
}
