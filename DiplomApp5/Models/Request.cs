using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DiplomApp5.Models
{
    [Table("request")]
    public class Request
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Vendor { get; set; }
        public string Model { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int ProfileId { get; set; }
        public int StatusId { get; set; }
        public int RequesterId { get; set; }
        public DateTime CompleteTime { get; set; }

        [ForeignKey("ProfileId")]
        public virtual UserProfile Profile { get; set; }

        [ForeignKey("StatusId")]
        public virtual RequestStatus RequestStatus { get; set; }

        [JsonIgnore]
        public virtual ICollection<RequestChat> RequestChat { get; set; } = new HashSet<RequestChat>();
    }
}
