using Microsoft.AspNetCore.Identity;

namespace OnionPortfolioProject.Domain;

public class WhoAmI : IdentityUser<Guid>
{
    public Guid Id { get; set; }
    public string PhotoPath { get; set; }
    public string Desc { get; set; }
    public string CvPath { get; set; }
    public List<Link>? Links { get; set; }
    public List<Skill>? Skills { get; set; }
    public WhoAmI() : base()
    {
        Id = Guid.NewGuid(); 
    }
}