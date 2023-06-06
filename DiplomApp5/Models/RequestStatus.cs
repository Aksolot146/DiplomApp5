using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DiplomApp5.Models
{
    [Table("requeststatus")]
    public class RequestStatus
    {
        public int Id { get; set; }
        public string Statusname { get; set; }

        //[JsonIgnore]
        public virtual ICollection<Request> Request { get; set; } = new HashSet<Request>();
    }
}
