using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DiplomApp5.Models
{
    [Table("department")]
    public class Department
    {
        public int Id { get; set; }
        public string Deptname { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserProfile> Profile { get; set; } = new HashSet<UserProfile>();
    }
}
