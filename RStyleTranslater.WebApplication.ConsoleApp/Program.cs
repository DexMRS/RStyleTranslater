using System;
using Nancy.Hosting.Self;

namespace RStyleTranslater.WebApplication.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:3100";
            using (var host = new NancyHost(new Uri(url)))
            {
                Console.WriteLine($"Start web server on {url}\nOpen it in your browser...\nPress any key to stop it...");
                host.Start();
                Console.ReadKey();
                host.Stop();
            }
        }
    }
}
