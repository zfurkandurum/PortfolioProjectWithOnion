using OnionPortfolioProject.Domain;

namespace OnionProtfolioProject.Application.Interfaces.Repositories;

public interface IUserRepository
{ 
    WhoAmI GetWhoAmIById(Guid id);
    void AddWhoAmI(WhoAmI whoAmI);
    void UpdateWhoAmI(WhoAmI whoAmI);
    void DeleteWhoAmI(Guid id);
}