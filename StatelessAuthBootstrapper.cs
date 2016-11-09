using Nancy.TinyIoc;
using Nancy.Bootstrapper;
using Nancy.Authentication.Stateless;

namespace Nancy.Demo.Authentication.Stateless.Jwt
{
    public class StatelessAuthBootstrapper : DefaultNancyBootstrapper
    {
        protected override void RequestStartup(TinyIoCContainer requestContainer, IPipelines pipelines, NancyContext context)
        {
           
            var configuration =
                new StatelessAuthenticationConfiguration(nancyContext =>
                    {
                      
                        var apiKey = (string)nancyContext.Request.Headers.Authorization;

                         
                        return UserDatabase.ValidateToken(apiKey);
                    });

            AllowAccessToConsumingSite(pipelines);

            StatelessAuthentication.Enable(pipelines, configuration);
        }

        static void AllowAccessToConsumingSite(IPipelines pipelines)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline(x =>
                {
                    x.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    x.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,DELETE,PUT,OPTIONS");
                });
        }
    }
}