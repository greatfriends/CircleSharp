using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircleSharp.Models
{
  public class CreateSpaceResult_Space
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("emoji")]
    public string Emoji { get; set; }

    [JsonProperty("space_group_id")]
    public int SpaceGroupId { get; set; }

    [JsonProperty("space_group_name")]
    public string SpaceGroupName { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("community_id")]
    public int CommunityId { get; set; }

    [JsonProperty("is_private")]
    public bool IsPrivate { get; set; }

    [JsonProperty("hide_post_settings")]
    public object HidePostSettings { get; set; }

    [JsonProperty("display_view")]
    public string DisplayView { get; set; }

    [JsonProperty("post_ids")]
    public List<object> PostIds { get; set; }

    [JsonProperty("is_post_disabled")]
    public object IsPostDisabled { get; set; } 

  }

  public class CreateSpaceResult 
  {
    [JsonProperty("success")]
    public bool Success { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("space")]
    public CreateSpaceResult_Space Space { get; set; }
  }

  public class CreateSpaceResult_Error
  {
    [JsonProperty("success")]
    public bool Success { get; set; }

    [JsonProperty("errors")]
    public string Errors { get; set; }
  }
}
