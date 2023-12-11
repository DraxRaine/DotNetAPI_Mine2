using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    DataContextDapper _dapper;

    public UserController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("TestConnection")]

    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("Select getdate()");
    }

    [HttpGet("GetUsers")]

    // public IEnumerable<User> GetUsers()
    public IEnumerable<User> GetUsers()
    {
        string sql = @"select [UserId],
            [FirstName],
            [LastName],
            [Email],
            [Gender],
            [Active] from TutorialAppSchema.Users";

        IEnumerable<User> users = _dapper.LoadData<User>(sql);
        return users;

    }

    [HttpGet("GetSingleUser/{userId}")]

    // public IEnumerable<User> GetUsers()
    public User GetSingleUser(int userId)
    {
        string sql = @"
        select [UserId],
            [FirstName],
            [LastName],
            [Email],
            [Gender],
            [Active] from TutorialAppSchema.Users
            WHERE UserId = " + userId.ToString();
        
        User user = _dapper.LoadDataSingle<User>(sql);
        return user;

    }

}
