using Microsoft.EntityFrameworkCore;
using CompleteDeveloperNetworkAPI.Models;

namespace CompleteDeveloperNetworkAPI.Data
{
  public class APIContext:DbContext
  {
    public DbSet<Freelancer> FreelancerInfo { get; set; }
    public APIContext(DbContextOptions<APIContext>options) : base(options)
    {

    }
  }
}
