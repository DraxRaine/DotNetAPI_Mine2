namespace DotnetAPI
{
    public partial class UserJobInfo
    {
        public int UserId { get; set; }
        public string? JobTitle { get; set; } = null;
        public string? Department { get; set; } = null;

// I set string to string? and '= null' so that I would not need to set
// the fields to null within the constructor.

        // public UserJobInfo()
        // {
        //     if (JobTitle == null)
        //     {
        //         JobTitle = "";
        //     }
        //     if (Department == null)
        //     {
        //         Department = "";
        //     }
        // }
    }


}