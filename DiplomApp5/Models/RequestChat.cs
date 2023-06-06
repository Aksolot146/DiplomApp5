using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DiplomApp5.Models
{
    [Table("requestchat")]
    public class RequestChat
    {
        public int Id { get; set; }
        public DateTime PubTime { get; set; }
        public string Message { get; set; }
        public int ProfileId { get; set; }
        public int RequestId { get; set; }

        [ForeignKey("ProfileId")]
        public virtual UserProfile Profile { get; set; }

        [ForeignKey("RequestId")]
        public virtual Request Request { get; set; }
    }
}
