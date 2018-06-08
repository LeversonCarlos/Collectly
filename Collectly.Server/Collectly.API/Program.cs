using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Collectly
{
   public class Program
   {
      public static void Main(string[] args)
      {
         Console.Title = "Collectly.API";
         BuildWebHost(args).Run();
      }

      public static IWebHost BuildWebHost(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
              .UseStartup<Startup>()
              .Build();
   }
}