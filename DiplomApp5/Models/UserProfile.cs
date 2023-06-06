using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DiplomApp5.Models
{
    [Table("userprofile")]
    public class UserProfile
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public int DeptId { get; set; }
        public int UserId { get; set; }
        public int RankId { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("RankId")]
        public virtual UserRank UserRank { get; set; }
        [ForeignKey("DeptId")]
        public virtual Department Department { get; set; }

        [JsonIgnore]
        public virtual ICollection<Request> Request { get; set; } = new HashSet<Request>();

        [JsonIgnore]
        public virtual ICollection<RequestChat> RequestChat { get; set; } = new HashSet<RequestChat>();
    }
}
