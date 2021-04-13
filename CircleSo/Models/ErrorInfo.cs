using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CircleSo.Models
{
  public class ErrorInfo
  { 
      [JsonPropertyName("status")]
      public string Status { get; set; }

      [JsonPropertyName("message")]
      public string Message { get; set; }
    } 
}
