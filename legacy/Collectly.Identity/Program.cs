using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Collectly.Identity
{
   public class Program
   {
      public static void Main(string[] args)
      {
         Console.Title = "Collectly.Identity";
         BuildWebHost(args).Run();
      }

      public static IWebHost BuildWebHost(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
              .UseStartup<Startup>()
              .Build();
   }
}