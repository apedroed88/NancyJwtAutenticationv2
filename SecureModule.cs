using Nancy.Security;

namespace Nancy.Demo.Authentication.Stateless.Jwt
{
    public class SecureModule : NancyModule
    {
        public SecureModule() : base("api/v2/secure")
        {
            this.RequiresAuthentication();
            this.RequiresClaims(x => x.Type == "Role" && x.Value == "Admin");


            Get("/", args =>
            {
                //Context.CurrentUser foi definido pela StatelessAuthentication no pipeline
                var identity = this.Context.CurrentUser;

                //Retornar as informações seguras em uma resposta json

                return this.Response.AsJson(new
                {
                    SecureContent = "Here is a secure content that you can only see if you provide a correct api key",
                    
                });
            });


        }

    }
}