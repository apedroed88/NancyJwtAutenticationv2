namespace Nancy.Demo.Authentication.Stateless
{
    using Nancy;

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", _ => "This is a simple stateless authentication demo with Jwt tokens.");
        }
    }
}
