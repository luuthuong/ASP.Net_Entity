namespace Netpower.Training.Intern2022.API.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
    public class UserUpdateDTO
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
