using System.Text.Json.Serialization;

namespace MessageApp.Core;


    public class MessageModel
    {
        [JsonPropertyName("messageId")]
        public Guid MessageId { get; set; }
        [JsonPropertyName("messageVersion")]
        public string? MessageVersion { get; set; }
        [JsonPropertyName("messageDada")]
        public dynamic? MessageDada { get; set; } 
    }

