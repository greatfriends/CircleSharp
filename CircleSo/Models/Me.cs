using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CircleSo.Models
{
  public class MeUserPrefs
  {
    [JsonPropertyName("has_seen_welcome_popup")]
    public bool HasSeenWelcomePopup { get; set; }
  }

  public class MeProfileInfo
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

  public class Me
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
    public DateTimeOffset AcceptedTermsAt { get; set; }

    [JsonPropertyName("accepted_privacy_at")]
    public DateTimeOffset AcceptedPrivacyAt { get; set; }

    [JsonPropertyName("admin")]
    public object Admin { get; set; }

    [JsonPropertyName("prefs")]
    public MeUserPrefs Prefs { get; set; }

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [JsonPropertyName("headline")]
    public string Headline { get; set; }

    [JsonPropertyName("posts_count")]
    public int PostsCount { get; set; }

    [JsonPropertyName("comments_count")]
    public int CommentsCount { get; set; }

    [JsonPropertyName("profile_info")]
    public MeProfileInfo ProfileInfo { get; set; }

    [JsonPropertyName("public_uid")]
    public string PublicUid { get; set; }

    [JsonPropertyName("affiliate_code")]
    public string AffiliateCode { get; set; }

    [JsonPropertyName("affiliate_ref")]
    public string AffiliateRef { get; set; }

    [JsonPropertyName("password_confirmed_at")]
    public DateTimeOffset? PasswordConfirmedAt { get; set; }

    [JsonPropertyName("password_confirmation_sent_at")]
    public DateTimeOffset? PasswordConfirmationSentAt { get; set; }

    [JsonPropertyName("password_set_at")]
    public DateTimeOffset? PasswordSetAt { get; set; }

    [JsonPropertyName("terms_of_service")]
    public object TermsOfService { get; set; }

    [JsonPropertyName("attachable_sgid")]
    public string AttachableSgid { get; set; }
  }


}
