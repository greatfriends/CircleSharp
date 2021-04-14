using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircleSharp.Models
{
  public class InvitationResultPrefs
  {
    [JsonProperty("has_seen_welcome_popup")]
    public bool HasSeenWelcomePopup { get; set; }
  }

  public class InvitationResultProfileInfo
  {
    [JsonProperty("website")]
    public string Website { get; set; }

    [JsonProperty("location")]
    public string Location { get; set; }

    [JsonProperty("twitter_url")]
    public string TwitterUrl { get; set; }

    [JsonProperty("facebook_url")]
    public string FacebookUrl { get; set; }

    [JsonProperty("linkedin_url")]
    public string LinkedinUrl { get; set; }

    [JsonProperty("instagram_url")]
    public string InstagramUrl { get; set; }

    [JsonProperty("make_my_email_public")]
    public string MakeMyEmailPublic { get; set; }
  }

  public class InvitationResultUser
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    [JsonProperty("bio")]
    public string Bio { get; set; }

    [JsonProperty("time_zone")]
    public string TimeZone { get; set; }

    [JsonProperty("accepted_terms_at")]
    public DateTimeOffset AcceptedTermsAt { get; set; }

    [JsonProperty("accepted_privacy_at")]
    public DateTimeOffset AcceptedPrivacyAt { get; set; }

    [JsonProperty("admin")]
    public object Admin { get; set; }

    [JsonProperty("prefs")]
    public InvitationResultPrefs Prefs { get; set; }

    [JsonProperty("created_at")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTimeOffset UpdatedAt { get; set; }

    [JsonProperty("headline")]
    public string Headline { get; set; }

    [JsonProperty("posts_count")]
    public int PostsCount { get; set; }

    [JsonProperty("comments_count")]
    public int CommentsCount { get; set; }

    [JsonProperty("profile_info")]
    public InvitationResultProfileInfo ProfileInfo { get; set; }

    [JsonProperty("public_uid")]
    public string PublicUid { get; set; }

    [JsonProperty("affiliate_code")]
    public string AffiliateCode { get; set; }

    [JsonProperty("affiliate_ref")]
    public string AffiliateRef { get; set; }

    [JsonProperty("password_confirmed_at")]
    public DateTimeOffset PasswordConfirmedAt { get; set; }

    [JsonProperty("password_confirmation_sent_at")]
    public object PasswordConfirmationSentAt { get; set; }

    [JsonProperty("password_set_at")]
    public DateTimeOffset PasswordSetAt { get; set; }

    [JsonProperty("terms_of_service")]
    public object TermsOfService { get; set; }

    [JsonProperty("attachable_sgid")]
    public string AttachableSgid { get; set; }
  }

  public class InvitationResult
  {
    [JsonProperty("success")]
    public bool Success { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("user")]
    public InvitationResultUser User { get; set; }
  }
}
