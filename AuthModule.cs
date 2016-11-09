namespace Nancy.Demo.Authentication.Stateless.Jwt
{
    public class AuthModule : NancyModule
    {
        public AuthModule() : base("api/v2/auth")
        {
            Post("/", args =>
              {
                  var jwtToken = UserDatabase.ValidateUser(
                      (string)this.Request.Form.Username,
                      (string)this.Request.Form.Password);

                  return string.IsNullOrEmpty(jwtToken)
                      ? new Response { StatusCode = HttpStatusCode.Unauthorized }
                      : this.Response.AsJson(new { jwtToken = jwtToken });
              });
        }

    }
}