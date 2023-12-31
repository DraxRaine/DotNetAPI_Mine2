using DotnetAPI.Data;
using DotnetAPI.Dtos;
using DotnetAPI.Models;
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

    // [HttpGet("TestConnection")]

    // public DateTime TestConnection()
    // {
    //     return _dapper.LoadDataSingle<DateTime>("Select getdate()");
    // }

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

    [HttpPut("EditUser")]
    public IActionResult EditUser(User user)
    {
        string sql = @"
        UPDATE TutorialAppSchema.Users SET
            [FirstName] = '" + user.FirstName + 
            "',[LastName] = '" + user.LastName + 
            "',[Email] = '" + user.Email + 
            "',[Gender] = '" + user.Gender + 
            "',[Active] = '" + user.Active + 
        "' WHERE UserId = " + user.UserId;

        Console.WriteLine(sql);

        if(_dapper.ExecuteSql(sql))
        {
            return Ok();
        }
        
        throw new Exception("Failed to update user man... This really sucks.");
    }

    [HttpPost("AddUser")]

    public IActionResult AddUser(UserToAddDto user)
    {
        string sql = @"
        INSERT INTO TutorialAppSchema.Users(
            [FirstName],
            [LastName],
            [Email],
            [Gender],
            [Active])
        VALUES(
            '" + user.FirstName + 
            "','" + user.LastName + 
            "','" + user.Email + 
            "','" + user.Gender + 
            "','" + user.Active + 
        "')";

        Console.WriteLine(sql);

        if(_dapper.ExecuteSql(sql))
        {
            return Ok();
        }
        
        throw new Exception("Failed to add user man... This sucks too.");
    }

    [HttpDelete("Delete")]

    public IActionResult DeleteUser(int userId)
    {
        string sql = @"
        delete from TutorialAppSchema.Users where UserId = " + userId.ToString();

        Console.WriteLine(sql);

        if(_dapper.ExecuteSql(sql))
        {
            return Ok();
        }
        
        throw new Exception("Failed to Delete user man... This really sucks too.");
    }

    

}
