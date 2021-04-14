using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircleSharp.Models
{
  public class ChatRoomMessage
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("chat_room_id")]
    public int ChatRoomId { get; set; }

    [JsonProperty("chat_room_participant_id")]
    public int ChatRoomParticipantId { get; set; }

    [JsonProperty("body")]
    public string Body { get; set; }

    [JsonProperty("created_at")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTimeOffset UpdatedAt { get; set; }
  }

  public class DirectMessageResult
  {
    [JsonProperty("success")]
    public bool Success { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("chat_room_message")]
    public ChatRoomMessage ChatRoomMessage { get; set; }
  } 
}
