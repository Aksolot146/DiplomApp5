using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomApp5.Models
{
    [Table("currentuser")]
    public class CurrentUser
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int? DeptId { get; set; }
        public int UserId { get; set; }
        public int RankId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string SessionId { get; set; }
    }
}