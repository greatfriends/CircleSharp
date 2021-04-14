using Newtonsoft.Json; 
using System.Collections.Generic; 

namespace CircleSharp.Models
{ 
  public class CommunityPrefs
  {
    [JsonProperty("has_posts")]
    public bool HasPosts { get; set; }

    [JsonProperty("has_spaces")]
    public bool HasSpaces { get; set; }

    [JsonProperty("brand_color")]
    public string BrandColor { get; set; }

    [JsonProperty("has_seen_widget")]
    public bool HasSeenWidget { get; set; }

    [JsonProperty("has_invited_member")]
    public bool HasInvitedMember { get; set; }

    [JsonProperty("has_completed_onboarding")]
    public bool HasCompletedOnboarding { get; set; }

    [JsonProperty("has_topics")]
    public bool? HasTopics { get; set; }
  }

  public class CommunityList
  {
    public List<Community> Communities { get; set; }
  }

  public class Community
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("icon_url")]
    public string IconUrl { get; set; }

    [JsonProperty("logo_url")]
    public string LogoUrl { get; set; }

    [JsonProperty("owner_id")]
    public int OwnerId { get; set; }

    [JsonProperty("is_private")]
    public bool IsPrivate { get; set; }

    [JsonProperty("space_ids")]
    public List<int> SpaceIds { get; set; }

    [JsonProperty("last_visited_by_current_user")]
    public bool? LastVisitedByCurrentUser { get; set; }

    [JsonProperty("default_existing_member_space_id")]
    public int DefaultExistingMemberSpaceId { get; set; }

    [JsonProperty("root_url")]
    public string RootUrl { get; set; }

    [JsonProperty("display_on_switcher")]
    public bool DisplayOnSwitcher { get; set; }

    [JsonProperty("prefs")]
    public CommunityPrefs Prefs { get; set; }
  }


}
