using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircleSharp.Models
{
  public class Space 
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
    public bool HidePostSettings { get; set; }

    [JsonProperty("display_view")]
    public string DisplayView { get; set; }

    [JsonProperty("post_ids")]
    public List<int> PostIds { get; set; }

    [JsonProperty("is_post_disabled")]
    public bool IsPostDisabled { get; set; }

    [JsonProperty("hide_topic_settings")]
    public bool HideTopicSettings { get; set; }

    [JsonProperty("is_topic_disabled")]
    public bool IsTopicDisabled { get; set; } 
  }


}
