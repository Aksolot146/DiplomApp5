using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DiplomApp5.Models
{
    [Table("requestvendor")]
    public class RequestVendor
    {
        public int Id { get; set; }
        public string Vendorname { get; set; }
        
        public int TitleId { get; set; }

        [ForeignKey("TitleId")]
        public virtual RequestTitle RequestTitle { get; set; }

        //[JsonIgnore]
        public virtual ICollection<RequestModel> RequestModel { get; set; } = new HashSet<RequestModel>();
    }
}
