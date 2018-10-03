using Nancy;

namespace RStyleTranslater.WebApplication.ConsoleApp.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["index.html"];
        }
    }
}
