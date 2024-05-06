using OnionPortfolioProject.Domain;
using OnionProtfolioProject.Application.Interfaces.Repositories;
using PortfolioProjectOnion.Persistence.Context;

namespace OnionProtfolioProject.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataDbContext _context;

    public UserRepository(DataDbContext context)
    {
        _context = context;
    }
   
    public WhoAmI GetWhoAmIById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void AddWhoAmI(WhoAmI whoAmI)
    {
        throw new NotImplementedException();
    }

    public void UpdateWhoAmI(WhoAmI whoAmI)
    {
        throw new NotImplementedException();
    }

    public void DeleteWhoAmI(Guid id)
    {
        throw new NotImplementedException();
    }
}