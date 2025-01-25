using eCommerence.Core.DTO;
using eCommerence.Core.Entities;
using eCommerence.Core.IRepositoryContract;

namespace eCommerence.Infrastructure.RepositoryContract;

public class UserRepository : IUserRepository
{
    public Task<ApplicationUser> AddUser(ApplicationUser user)
    { 
        user.Id = new Guid();
        return Task.FromResult(user);
    }

    public Task<ApplicationUser> GetUserByEmailAndPassword(string Email, string Password)
    {
        ApplicationUser user =  new ApplicationUser()
        {
            Id = new Guid(),
            Email = "m.seoud42@gmail.com",
            Password = "test123@",
            PersonName = "Mohamed Seoud",
            Gender = GenderOption.Male.ToString(),
        };
        return Task.FromResult(user);
    }
}
