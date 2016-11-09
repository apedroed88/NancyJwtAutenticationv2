using System;

namespace Nancy.Demo.Authentication.Stateless.Jwt.Secure
{
    public class JwtPayLoad
    {
        public string UserName { get; set; }
        public string Role { get; set; }
        // It was added 2 minutes only for demo, do not do it in production.
        public DateTime Exp { get; set; } 

        public JwtPayLoad (string userName, string role, DateTime tokenExp)
        {
          UserName = userName;
          Role = role;
          Exp = tokenExp;
        }    
    }
}