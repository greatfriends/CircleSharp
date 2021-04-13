using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CircleSo.Models
{
  public class Prefs
  {
    [JsonPropertyName("has_seen_welcome_popup")]
    public bool HasSeenWelcomePopup { get; set; }
  }

  public class ProfileInfo
  {
    [JsonPropertyName("website")]
    public string Website { get; set; }

    [JsonPropertyName("location")]
    public string Location { get; set; }

    [JsonPropertyName("twitter_url")]
    public string TwitterUrl { get; set; }

    [JsonPropertyName("facebook_url")]
    public string FacebookUrl { get; set; }

    [JsonPropertyName("linkedin_url")]
    public string LinkedinUrl { get; set; }

    [JsonPropertyName("instagram_url")]
    public string InstagramUrl { get; set; }

    [JsonPropertyName("make_my_email_public")]
    public string MakeMyEmailPublic { get; set; }
  }

  public class UserInfo
  {
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("bio")]
    public string Bio { get; set; }

    [JsonPropertyName("time_zone")]
    public string TimeZone { get; set; }

    [JsonPropertyName("accepted_terms_at")]
    public DateTime AcceptedTermsAt { get; set; }

    [JsonPropertyName("accepted_privacy_at")]
    public DateTime AcceptedPrivacyAt { get; set; }

    [JsonPropertyName("admin")]
    public object Admin { get; set; }

    [JsonPropertyName("prefs")]
    public Prefs Prefs { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("headline")]
    public string Headline { get; set; }

    [JsonPropertyName("posts_count")]
    public int PostsCount { get; set; }

    [JsonPropertyName("comments_count")]
    public int CommentsCount { get; set; }

    [JsonPropertyName("profile_info")]
    public ProfileInfo ProfileInfo { get; set; }

    [JsonPropertyName("public_uid")]
    public string PublicUid { get; set; }

    [JsonPropertyName("affiliate_code")]
    public string AffiliateCode { get; set; }

    [JsonPropertyName("affiliate_ref")]
    public string AffiliateRef { get; set; }

    [JsonPropertyName("password_confirmed_at")]
    public DateTime PasswordConfirmedAt { get; set; }

    [JsonPropertyName("password_confirmation_sent_at")]
    public object PasswordConfirmationSentAt { get; set; }

    [JsonPropertyName("password_set_at")]
    public DateTime PasswordSetAt { get; set; }

    [JsonPropertyName("terms_of_service")]
    public object TermsOfService { get; set; }

    [JsonPropertyName("attachable_sgid")]
    public string AttachableSgid { get; set; }
  }


}
