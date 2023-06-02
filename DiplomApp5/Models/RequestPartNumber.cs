using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DiplomApp5.Models
{
    [Table("requestpartnumber")]
    public class RequestPartNumber
    {
        public int Id { get; set; }
        public string PMname { get; set; }
        public int Price { get; set; }
        public DateTime RegDate { get; set; }

        public int ModelId { get; set; }

        [ForeignKey("ModelId")]
        public virtual RequestModel RequestModel { get; set; }
    }
}
