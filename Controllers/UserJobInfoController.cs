using DotnetAPI.Data;
using DotnetAPI.Dtos;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserJobInfoController : ControllerBase
{
    DataContextDapper _dapper;

    public UserJobInfoController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("GetUserJobInfo")]

    public IEnumerable<UserJobInfo> GetUserJobInfo()
    {
        string sql = @"
        Select [UserId], [JobTitle], [Department] FROM TutorialAppSchema.UserJobInfo WITH (NOLOCK)";

        IEnumerable<UserJobInfo> userJobInfos = _dapper.LoadData<UserJobInfo>(sql);
        return userJobInfos;

    }

    [HttpGet("SingleUserJobInfo")]

    public UserJobInfo GetSingleUserJobInfo(int userId)
    {
        string sql = @"Select [UserId], [JobTitle], [Department] FROM TutorialAppSchema.UserJobInfo WITH (NOLOCK) WHERE UserId = " + userId;

        UserJobInfo userJobInfo = _dapper.LoadDataSingle<UserJobInfo>(sql);

        return userJobInfo;
    }

    [HttpPut("EditUserJobInfo")]

    public IActionResult EditUserJobInfo(UserJobInfo userJobInfo)
    {
        string sql = @"Update TutorialAppSchema.UserJobInfo SET 
                        [JobTitle] = '" + userJobInfo.JobTitle + 
                        "', [Department] = '" + userJobInfo.Department + 
                        "' WHERE UserId = " + userJobInfo.UserId;

        Console.WriteLine(sql);

        if(_dapper.ExecuteSql(sql))
        {
            return Ok();
        }

        throw new Exception("Update UserJobInfo failed");
    }

    [HttpPost("AddUserJobInfo")]

    public IActionResult AddUserJobInfo(UserJobInfoToAddDto userJobInfo)
    {
        string sql = @"INSERT INTO TutorialAppSchema.UserJobInfo(
            [JobTitle], [Department]) VALUES ('" + userJobInfo.JobTitle + "', '" + userJobInfo.Department + "')";

        Console.WriteLine(sql);

        if(_dapper.ExecuteSql(sql))
        {
            return Ok();
        }

        throw new Exception("Failed to add new UserJobInfo");
    }

    [HttpDelete("DeleteUserJobInfo")]

    public IActionResult DeleteUserJobInfo(int userId)
    {
        string sql = @"DELETE FROM TutorialAppSchema.UserJobInfo WHERE UserId = " + userId.ToString();

        Console.WriteLine(sql);

        if(_dapper.ExecuteSql(sql))
        {
            return Ok();
        }

        throw new Exception("Failed to DELETE UserJobInfo");

    }


    // [HttpDelete("Delete")]

    // public IActionResult DeleteUser(int userId)
    // {
    //     string sql = @"
    //     delete from TutorialAppSchema.Users where UserId = " + userId.ToString();

    //     Console.WriteLine(sql);

    //     if(_dapper.ExecuteSql(sql))
    //     {
    //         return Ok();
    //     }
        
    //     throw new Exception("Failed to Delete user man... This really sucks too.");
    // }
    

}
