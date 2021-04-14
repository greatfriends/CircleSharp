using Newtonsoft.Json;
using System;
using System.Collections.Generic; 

namespace CircleSharp.Models
{
  public class SpaceGroup 
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("is_hidden_from_non_members")]
    public bool IsHiddenFromNonMembers { get; set; }

    [JsonProperty("allow_members_to_create_spaces")]
    public bool AllowMembersToCreateSpaces { get; set; }

    [JsonProperty("community_id")]
    public int CommunityId { get; set; }

    [JsonProperty("space_order_array")]
    public List<int> SpaceOrderArray { get; set; }

    [JsonProperty("created_at")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTimeOffset UpdatedAt { get; set; }

    [JsonProperty("automatically_add_members_to_new_spaces")]
    public bool AutomaticallyAddMembersToNewSpaces { get; set; }

    [JsonProperty("add_members_to_space_group_on_space_join")]
    public bool AddMembersToSpaceGroupOnSpaceJoin { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("hide_non_member_spaces_from_sidebar")]
    public bool HideNonMemberSpacesFromSidebar { get; set; }
  }


}
