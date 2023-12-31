namespace DotnetAPI.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? Gender { get; set; } = null;
        public bool Active { get; set; }

// I set string to string? and '= null' so that I would not need to set
// the fields to null within the constructor.

        // public Users()
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