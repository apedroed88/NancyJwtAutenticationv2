using Nancy.Owin;
using Microsoft.AspNetCore.Builder;

namespace Nancy.Demo.Authentication.Stateless.Jwt
{

    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(x => x.UseNancy());
        }
    }
}
