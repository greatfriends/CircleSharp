using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircleSharp.Models
{
  public class User 
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("user_id")]
    public int UserId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("headline")]
    public string Headline { get; set; }

    [JsonProperty("bio")]
    public string Bio { get; set; }

    [JsonProperty("topics_count")]
    public int TopicsCount { get; set; }

    [JsonProperty("posts_count")]
    public int PostsCount { get; set; }

    [JsonProperty("comments_count")]
    public int CommentsCount { get; set; }

    [JsonProperty("avatar_url")]
    public string AvatarUrl { get; set; }

    [JsonProperty("public_uid")]
    public string PublicUid { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("community_id")]
    public int CommunityId { get; set; }

    [JsonProperty("member_tags")]
    public List<string> MemberTags { get; set; }

    [JsonProperty("profile_url")]
    public string ProfileUrl { get; set; }

    [JsonProperty("location")]
    public string Location { get; set; }

    [JsonProperty("website_url")]
    public string WebsiteUrl { get; set; }

    [JsonProperty("instagram_url")]
    public string InstagramUrl { get; set; }

    [JsonProperty("twitter_url")]
    public string TwitterUrl { get; set; }

    [JsonProperty("linkedin_url")]
    public string LinkedinUrl { get; set; }

    [JsonProperty("facebook_url")]
    public string FacebookUrl { get; set; }

    [JsonProperty("accepted_invitation")]
    public string AcceptedInvitation { get; set; }
  }


}
