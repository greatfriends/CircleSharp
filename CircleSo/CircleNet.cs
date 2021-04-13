using CircleSo.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace CircleSo
{
  public class CircleNet
  {
    private readonly string host;
    private readonly string token;

    public CircleNet(IConfiguration config)
    {
      if (config == null) throw new ArgumentNullException(nameof(config));

      host = config["CircleNet:host"];
      token = config["CircleNet:token"];

      if (string.IsNullOrEmpty(host)) throw new InvalidOperationException("'CircleNet:host' is required in configuration.");
      if (string.IsNullOrEmpty(token)) throw new InvalidOperationException("'CircleNet:token' is required in configuration.");
    }

    public UserInfo GetUserInfo()
    {
      var client = new RestClient($"{host}/api/v1/me");

      var request = new RestRequest(Method.GET);
      request.AddHeader("Authorization", $"Token {token}");

      var response = client.Execute<UserInfo>(request);

      if (response.Data.Id == 0)
      {
        var err = JsonConvert.DeserializeObject<ErrorInfo>(response.Content);
        throw new Exception($"{err.Status}: {err.Message}");
      }

      return response.Data;
    }
  }
}
