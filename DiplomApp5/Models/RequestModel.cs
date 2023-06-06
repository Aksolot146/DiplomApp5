using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DiplomApp5.Models
{
    [Table("requestmodel")]
    public class RequestModel
    {
        public int Id { get; set; }
        public string Modelname { get; set; }
        public string Description { get; set; }

        public int VendorId { get; set; }

        [ForeignKey("VendorId")]
        public virtual RequestVendor RequestVendor { get; set; }

        //[JsonIgnore]
        public virtual ICollection<RequestPartNumber> RequestPartNumber { get; set; } = new HashSet<RequestPartNumber>();
    }
}
