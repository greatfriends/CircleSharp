using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;

namespace CircleSo.CLI
{
  class Program
  {

    static void Main(string[] args)
    {
      CircleNet c = CreateCircleNet();

      Do_UserInfo(c);
    }
     
    private static void Do_UserInfo(CircleNet c)
    {
      try
      {
        var u = c.GetUserInfo();
        Dump(u);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private static CircleNet CreateCircleNet()
    {
      var builder = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddUserSecrets<Program>();
      var config = builder.Build();

      var c = new CircleNet(config);
      return c;
    }

    private static void Dump(object obj)
    {
      var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
      Console.WriteLine(json);
    }
  }
}
