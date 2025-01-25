
using eCommerence.Core.Entities;

namespace eCommerence.Core.IRepositoryContract;

public interface IUserRepository
{
    public Task<ApplicationUser?> AddUser(ApplicationUser user);
    public Task<ApplicationUser?> GetUserByEmailAndPassword(string Email, string Password);


}
