using Jose;
using System.Linq;
using System.Collections.Generic;
using Nancy.Demo.Authentication.Stateless.Jwt.Models;
using Nancy.Demo.Authentication.Stateless.Jwt.Secure;
using System.Security.Claims;
using System;
using System.Security.Principal;

namespace Nancy.Demo.Authentication.Stateless.Jwt
{
    public class UserDatabase
    {
        private static readonly List<User> Users = new List<User>();
        private static readonly byte[] SecretKey = new byte[] { 164, 60, 194, 0, 161, 189, 41, 38, 130, 89, 141, 164, 45, 170, 159, 209, 69, 137, 243, 216, 191, 131, 47, 250, 32, 107, 231, 117, 37, 158, 225, 234 };
        static UserDatabase()
        {
            Users.Add(new User("user1", "123", "user"));
            Users.Add(new User("user2", "456", "Admin"));
        }

        public static string ValidateUser(string username, string password)
        {

            var userRecord = Users.FirstOrDefault(u => u.UserName == username && u.PassWord == password);

            if (userRecord == null)
                return null;
            
            var payload = new JwtPayLoad(userRecord.UserName, userRecord.Role, DateTime.Now.AddMinutes(2));

            return Jose.JWT.Encode(payload, SecretKey, JwsAlgorithm.HS256);
        }

        public static ClaimsPrincipal ValidateToken(string jwtToken)
        {
          
            if (string.IsNullOrEmpty(jwtToken))
                return null;
            
           
            var token = Jose.JWT.Decode<JwtPayLoad>(jwtToken, SecretKey);
            var exp = token.Exp;
            
            if (exp < DateTime.Now)
                return null;

            var claims = new GenericIdentity(token.UserName);
            claims.AddClaim(new Claim("Name", token.UserName));
            claims.AddClaim(new Claim("Role", token.Role));
            return new ClaimsPrincipal(claims);

        }


    }
}