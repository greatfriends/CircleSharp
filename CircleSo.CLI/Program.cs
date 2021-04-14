using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;

namespace CircleSharp.CLI
{
  class Program
  {
    // At this time, this console will use for quick testing the library.
    // Not a CLI.

    private static int Community_1;
    private static int Community_2;
    private static int SpaceGroup_11;
    private static int SpaceGroup_12;
    private static int SpaceGroup_21;
    private static int Space_11a;
    private static int Space_11b;
    private static int User_1a;
    private static IConfiguration config;

    static void Main(string[] args)
    {
      CircleNet c = CreateCircleNet();
      Community_1 = int.Parse(config["Ids:Community_1"]);
      Community_2 = int.Parse(config["Ids:Community_2"]);
      SpaceGroup_11 = int.Parse(config["Ids:SpaceGroup_11"]);
      SpaceGroup_12 = int.Parse(config["Ids:SpaceGroup_12"]);
      SpaceGroup_21 = int.Parse(config["Ids:SpaceGroup_21"]);
      Space_11a = int.Parse(config["Ids:Space_11a"]);
      Space_11b = int.Parse(config["Ids:Space_11b"]);
      User_1a = int.Parse(config["Ids:User_1a"]); 

      try
      {
        //Do_UserInfo(c);
        //Do_Communities(c);
        //Do_Community(c);
        //Do_SpaceGroups(c);
        //Do_SpaceGroup(c);

        //Do_Spaces(c);
        //Do_Space(c);

        //Do_CreateSpace(c);
        //Do_DeleteSpace(c);

        Do_Invitation(c);
        //Do_GetUsers(c);
        //Do_GetUser(c);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

    }

    private static void Do_GetUser(CircleNet c)
    {
      var u1 = c.GetUser(User_1a, Community_1);
      Dump(u1);
    }

    private static void Do_GetUsers(CircleNet c)
    {
      var items1 = c.GetUsers(Community_2);
      Dump(items1);
    }

    private static void Do_Invitation(CircleNet c)
    {
      var ms = DateTime.Now.Millisecond;
      var result = c.InviteMember(Community_1,
        $"user.{ms}@gfbd.co.th",
        null,
        Space_11a, Space_11b);

      Dump(result);
    }

    private static void Do_DeleteSpace(CircleNet c)
    {
      var result = c.DeleteSpace(90485, true);
      Dump(result);
    }

    private static void Do_CreateSpace(CircleNet c)
    {
      int ms = DateTime.Now.Millisecond;
      var result = c.CreateSpace(SpaceGroup_12, Community_1,
        $"Test Space {ms}", $"test-space-{ms}",
        true, true, true, true);
      Dump(result);
    }

    private static void Do_Space(CircleNet c)
    {
      var x = c.GetSpace(84774, Community_1);
      Dump(x);
    }

    private static void Do_Spaces(CircleNet c)
    {
      var items = c.GetSpaces(SpaceGroup_11, Community_1);
      Dump(items);
      var items2 = c.GetSpaces(SpaceGroup_21, Community_2);
      Dump(items2);
    }

    private static void Do_SpaceGroups(CircleNet c)
    {
      var u = c.GetSpaceGroups();
      Dump(u);
    }

    private static void Do_SpaceGroup(CircleNet c)
    {
      var u2 = c.GetSpaceGroup(SpaceGroup_11, Community_1);
      Dump(u2);
      var u1 = c.GetSpaceGroup(SpaceGroup_21, Community_2);
      Dump(u1);
    }

    private static void Do_Communities(CircleNet c)
    {
      var u = c.GetCommunities();
      Dump(u);
    }

    private static void Do_Community(CircleNet c)
    {
      var u = c.GetCommunity(Community_1);
      Dump(u);
    }

    private static void Do_UserInfo(CircleNet c)
    {
      var u = c.GetMe();
      Dump(u);
    }

    private static CircleNet CreateCircleNet()
    {
      config = InitConfiguration();

      var c = new CircleNet(config);
      return c;
    }

    private static IConfigurationRoot InitConfiguration()
    {
      var builder = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddUserSecrets<Program>();
      var config = builder.Build();
      return config;
    }

    private static void Dump(object obj)
    {
      var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
      Console.WriteLine(json);
    }
  }
}
