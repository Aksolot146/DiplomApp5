using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DiplomApp5.Models
{
    [Table("userrank")]
    public class UserRank
    {
        public int Id { get; set; }
        public string Rankname { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserProfile> Profile { get; set; } = new HashSet<UserProfile>();
    }
}
