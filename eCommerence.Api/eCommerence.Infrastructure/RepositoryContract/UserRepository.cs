using Dapper;
using eCommerence.Core.DTO;
using eCommerence.Core.Entities;
using eCommerence.Core.IRepositoryContract;
using eCommerence.Infrastructure.DbContext;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;

namespace eCommerence.Infrastructure.RepositoryContract;

internal class UserRepository : IUserRepository
{
    private readonly DapperDbContext _dbContext;
    public UserRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext; 
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        //Generate a new unique user ID for the user
        user.Id = Guid.NewGuid();
        // SQL Query to insert user data into the "Users" table.
        string query = "INSERT INTO public.\"Users\" (\"Id\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@Id, @Email, @PersonName, @Gender, @Password)";
        int numOfRowsAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);
        if (numOfRowsAffected > 0) return user;
        return null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string Email, string Password)
    {
        //SQL query to select a user by Email and Password
        string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
        var loginParameters = new { Email = Email, Password = Password };
        ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync < ApplicationUser > (query, loginParameters);

        return user;
    }
}
