using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircleSo.Models
{ 
  public class DeleteSpaceResult 
  {
    [JsonProperty("success")]
    public bool Success { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; } 
  } 
}
