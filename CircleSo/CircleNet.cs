using CircleSharp.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CircleSharp
{
  public class CircleNet
  {
    private const string HostIsRequired = "'CircleNet:host' is required in configuration.";
    private const string TokenIsRequired = "'CircleNet:token' is required in configuration.";

    private readonly string host;
    private readonly string token;

    private Dictionary<bool, string> booleans = new Dictionary<bool, string>
    {
      [true] = "true",
      [false] = "false",
    };

    public CircleNet(IConfiguration config)
    {
      if (config == null) throw new ArgumentNullException(nameof(config));

      host = config["CircleNet:host"];
      token = config["CircleNet:token"];

      if (string.IsNullOrEmpty(host)) throw new InvalidOperationException(HostIsRequired);
      if (string.IsNullOrEmpty(token)) throw new InvalidOperationException(TokenIsRequired);
    }

    public CircleNet(string host, string token)
    {
      this.host = host;
      this.token = token;

      if (string.IsNullOrEmpty(host)) throw new InvalidOperationException(HostIsRequired);
      if (string.IsNullOrEmpty(token)) throw new InvalidOperationException(TokenIsRequired);
    }

    public Me GetMe()
    {
      var client = new RestClient($"{host}/api/v1/me");
      var request = CreateRequestWithAuth();

      var response = client.Execute<Me>(request);

      if (response.Data.Id == 0)
      {
        var err = JsonConvert.DeserializeObject<StatusResult>(response.Content);
        throw new Exception($"{err.Status}: {err.Message}");
      }

      return response.Data;
    }

    public List<Community> GetCommunities()
    {
      var client = new RestClient($"{host}/api/v1/communities");
      var request = CreateRequestWithAuth();

      var response = client.Execute<List<Community>>(request);

      if (response.Data.Count == 0)
      {
        var err = JsonConvert.DeserializeObject<StatusResult>(response.Content);
        throw new Exception($"{err.Status}: {err.Message}");
      }

      return response.Data;
    }

    public Community GetCommunity(int id)
      => GetCommunities().SingleOrDefault(x => x.Id == id);

    public List<SpaceGroup> GetSpaceGroups(int? communityId = null)
    {
      var client = new RestClient($"{host}/api/v1/space_groups");
      var request = CreateRequestWithAuth();

      if (communityId != null)
        request.AddQueryParameter("community_id", communityId.ToString());

      var response = client.Execute<List<SpaceGroup>>(request);

      if (response.Data.Count == 0)
      {
        var err = JsonConvert.DeserializeObject<StatusResult>(response.Content);
        throw new Exception($"{err.Status}: {err.Message}");
      }

      return response.Data;
    }

    public SpaceGroup GetSpaceGroup(int spaceGroupId, int? communityId = null)
    {
      var client = new RestClient($"{host}/api/v1/space_groups/{spaceGroupId}");
      var request = CreateRequestWithAuth();

      if (communityId != null)
        request.AddQueryParameter("community_id", communityId.ToString());

      var response = client.Execute<SpaceGroup>(request);

      if (response.Data.Id == 0)
      {
        var err = JsonConvert.DeserializeObject<StatusResult>(response.Content);
        throw new Exception($"{err.Status}: {err.Message}");
      }

      return response.Data;
    }

    public List<Space> GetSpaces(int spaceGroupId, int? communityId = null, string sort = "oldest")
    {
      string[] sorts = new[] { "oldest", "latest", "active" };
      if (!sorts.Contains(sort))
      {
        throw new ArgumentException($"sort must be in '{string.Join(',', sorts)}' only.", nameof(sort));
      }

      var client = new RestClient($"{host}/api/v1/spaces");
      var request = CreateRequestWithAuth();

      int page = 1;
      int maxPerPage = 60;
      request.AddQueryParameter("space_group_id", spaceGroupId.ToString());
      request.AddQueryParameter("per_page", maxPerPage.ToString());
      request.AddQueryParameter("page", page.ToString());
      request.AddQueryParameter("sort", sort);

      if (communityId != null)
        request.AddQueryParameter("community_id", communityId.ToString());

      var result = new List<Space>();
      IRestResponse<List<Space>> response;

      do
      {
        response = client.Execute<List<Space>>(request);
        result.AddRange(response.Data);

        request.AddOrUpdateParameter("page", (++page).ToString());
      } while (response.Data.Count > 0);

      return result;
    }

    public Space GetSpace(int spaceId, int? communityId = null)
    {
      var client = new RestClient($"{host}/api/v1/spaces/{spaceId}");
      var request = CreateRequestWithAuth();

      if (communityId != null)
        request.AddQueryParameter("community_id", communityId.ToString());


      var response = client.Execute<Space>(request);

      if (!response.IsSuccessful || response.Data.Id == 0)
      {
        if (response.ContentType == "text/plain")
        {
          throw new Exception(response.ErrorMessage);
        }

        var err = JsonConvert.DeserializeObject<StatusResult>(response.Content);
        if (err != null)
          throw new Exception($"{err.Status}: {err.Message}");
      }

      return response.Data;
    }

    public CreateSpaceResult CreateSpace(int spaceGroupId, int communityId, string name, string slug,
      bool isPrivate, bool isHidden, bool isHiddenFromNonMember, bool isPostDiabled)
    {
      var client = new RestClient($"{host}/api/v1/spaces");
      var request = CreateRequestWithAuth(Method.POST);

      request.AddQueryParameter("space_group_id", spaceGroupId.ToString());
      request.AddQueryParameter("community_id", communityId.ToString());
      request.AddQueryParameter("name", name);
      request.AddQueryParameter("slug", slug);
      request.AddQueryParameter("is_private", booleans[isPrivate]);
      request.AddQueryParameter("is_hidden", booleans[isHidden]);
      request.AddQueryParameter("is_hidden_from_non_members", booleans[isHiddenFromNonMember]);
      request.AddQueryParameter("is_post_disabled", booleans[isPostDiabled]);

      var response = client.Execute<CreateSpaceResult>(request);

      if (response.Data.Success == false)
      {
        var err = JsonConvert.DeserializeObject<CreateSpaceResult_Error>(response.Content);
        throw new Exception($"{err.Errors}");
      }

      return response.Data;
    }

    public SuccessResult DeleteSpace(int spaceId, bool forceDeleteNonEmptySpace = false)
    {
      try
      {
        var space = GetSpace(spaceId);
        if (!forceDeleteNonEmptySpace && space.PostIds.Count > 0)
        {
          return new SuccessResult
          {
            Success = false,
            Message = "This space is not empty"
          };
        }

        var client = new RestClient($"{host}/api/v1/spaces/{spaceId}");
        var request = CreateRequestWithAuth(Method.DELETE);

        var response = client.Execute<SuccessResult>(request);
        return response.Data;
      }
      catch (Exception ex)
      {
        return new SuccessResult
        {
          Success = false,
          Message = ex?.Message
        };
      }
    }
     
    public InvitationResult InviteMember(int communityId, string email, string name = null, params int[] spaceIds)
    {
      var client = new RestClient($"{host}/api/v1/community_members");
      var request = CreateRequestWithAuth(Method.POST);

      request.AddQueryParameter("email", email);
      request.AddQueryParameter("community_id", communityId.ToString());

      if (name == null)
      {
        name = email.Substring(0, email.IndexOf("@"))
          .Replace(".", " ").Replace("-", " ").Replace("+", " ");
        request.AddQueryParameter("name", name);
      }

      if (spaceIds != null)
      {
        var jsonSpaceIds = JsonConvert.SerializeObject(spaceIds);
        request.AddQueryParameter("space_ids[]", jsonSpaceIds);
      }

      var response = client.Execute<InvitationResult>(request);

      return response.Data;
    }

    public List<User> GetUsersBySpace(int spaceId, string sort = "latest")
    {
      string[] sorts = new[] { "oldest", "latest", "active" };
      if (!sorts.Contains(sort))
      {
        throw new ArgumentException($"sort must be in '{string.Join(',', sorts)}' only.", nameof(sort));
      }

      var client = new RestClient($"{host}/api/v1/community_members");
      var request = CreateRequestWithAuth();

      int page = 1;
      int maxPerPage = 60;
      request.AddQueryParameter("space_id", spaceId.ToString());
      request.AddQueryParameter("per_page", maxPerPage.ToString());
      request.AddQueryParameter("page", page.ToString());
      request.AddQueryParameter("sort", sort);

      var result = new List<User>();
      IRestResponse<List<User>> response;

      do
      {
        response = client.Execute<List<User>>(request);
        result.AddRange(response.Data);

        request.AddOrUpdateParameter("page", (++page).ToString());
      } while (response.Data.Count > 0);

      return result;
    }

    public List<User> GetUsers(int communityId, string sort = "latest")
    {
      string[] sorts = new[] { "oldest", "latest", "active" };
      if (!sorts.Contains(sort))
      {
        throw new ArgumentException($"sort must be in '{string.Join(',', sorts)}' only.", nameof(sort));
      }

      var client = new RestClient($"{host}/api/v1/community_members");
      var request = CreateRequestWithAuth();

      int page = 1;
      int maxPerPage = 60;
      request.AddQueryParameter("community_id", communityId.ToString());
      request.AddQueryParameter("per_page", maxPerPage.ToString());
      request.AddQueryParameter("page", page.ToString());
      request.AddQueryParameter("sort", sort);

      var result = new List<User>();
      IRestResponse<List<User>> response;

      do
      {
        response = client.Execute<List<User>>(request);
        result.AddRange(response.Data);

        request.AddOrUpdateParameter("page", (++page).ToString());
      } while (response.Data.Count > 0);

      return result;
    }

    public User GetUser(int userId, int? communityId = null)
    {

      var client = new RestClient($"{host}/api/v1/community_members/{userId}");
      var request = CreateRequestWithAuth();

      if (communityId != null)
        request.AddQueryParameter("community_id", communityId.ToString());

      var response = client.Execute<User>(request);

      if (response.Data.Id == 0)
      {
        var err = JsonConvert.DeserializeObject<StatusResult>(response.Content);
        throw new Exception($"{err.Status}: {err.Message}");
      }

      return response.Data;
    }

    public SuccessResult AddMemberToSpace(string email, int spaceId, int? communityId = null)
    {
      var client = new RestClient($"{host}/api/v1/space_members");
      var request = CreateRequestWithAuth(Method.POST);

      request.AddQueryParameter("email", email);
      request.AddQueryParameter("space_id", spaceId.ToString());

      if (communityId != null)
        request.AddQueryParameter("community_id", communityId.ToString());

      var response = client.Execute<SuccessResult>(request);
      return response.Data;
    }

    public SuccessResult RemoveMemberFromSpace(string email, int spaceId, int? communityId = null)
    {
      var client = new RestClient($"{host}/api/v1/space_members");
      var request = CreateRequestWithAuth(Method.DELETE);

      request.AddQueryParameter("email", email);
      request.AddQueryParameter("space_id", spaceId.ToString());

      if (communityId != null)
        request.AddQueryParameter("community_id", communityId.ToString());

      var response = client.Execute<SuccessResult>(request);
      return response.Data;
    }

    public DirectMessageResult DirectMessage(string email, string messageBody, int? communityId = null)
    {
      var client = new RestClient($"{host}/api/v1/messages");
      var request = CreateRequestWithAuth(Method.DELETE);

      request.AddQueryParameter("user_email", email);
      request.AddQueryParameter("message_body", messageBody);

      if (communityId != null)
        request.AddQueryParameter("community_id", communityId.ToString());

      var response = client.Execute<DirectMessageResult>(request);
      return response.Data;
    }
     
    private RestRequest CreateRequestWithAuth(Method method = Method.GET)
    {
      var request = new RestRequest(method);
      request.AddHeader("Authorization", $"Token {token}");

      return request;
    }
  }
}
