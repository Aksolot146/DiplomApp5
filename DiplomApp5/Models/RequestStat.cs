using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomApp5.Models
{
    [Table("requeststats")]
    public class RequestStat
    {
        public int Id { get; set; }
        public int ActualRequestsCount { get; set; }
        public int NonActualRequestsCount { get; set; }
        public float CompleteRequests { get; set; }
        public float DeclinedRequests { get; set; }
        public float ExpiredRequests { get; set; }
    }
}
