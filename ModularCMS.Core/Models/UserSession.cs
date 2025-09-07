using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ModularCMS.Core.Models
{
    public class UserSession
    {
        public int User_ID { get; set; }
        public string Username { get; set; } = "";
        public string User_Type { get; set; } = "";
        public string Role { get; set; } = "";
        public DateTime LoginTime { get; set; }
        public DateTime ExpiryTime { get; set; }
        public bool IsExpired => DateTime.Now > ExpiryTime;
        public bool IsValid => !IsExpired && User_ID > 0;

        // For JSON serialization
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public static UserSession? FromJson(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<UserSession>(json);
            }
            catch
            {
                return null;
            }
        }
    }
}
