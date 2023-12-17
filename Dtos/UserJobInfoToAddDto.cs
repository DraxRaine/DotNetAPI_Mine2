namespace DotnetAPI.Dtos
{
    public partial class UserJobInfoToAddDto
    {
        public int UserId { get; set; }
        public string? JobTitle { get; set; } = null;
        public string? Department { get; set; } = null;

// I set string to string? and '= null' so that I would not need to set
// the fields to null within the constructor.

        // public UserDto()
        // {
        //     if (FirstName == null)
        //     {
        //         FirstName = "";
        //     }
        //     if (LastName == null)
        //     {
        //         LastName = "";
        //     }
        //     if (Email == null)
        //     {
        //         Email = "";
        //     }
        //     if (Gender == null)
        //     {
        //         Gender = "";
        //     }
        // }
    }


}