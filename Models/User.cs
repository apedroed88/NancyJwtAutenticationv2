namespace Nancy.Demo.Authentication.Stateless.Jwt.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }
        public User (string username, string password, string role)
        {
          UserName = username;
          PassWord = password;
          Role = role;  
        }
    }
}