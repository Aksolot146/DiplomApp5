using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DiplomApp5.Models
{
    [Table("requesttitle")]
    public class RequestTitle
    {
        public int Id { get; set; }
        public string Titlename { get; set; }

        //[JsonIgnore]
        public virtual ICollection<RequestVendor> RequestVendor { get; set; } = new HashSet<RequestVendor>();
    }
}
