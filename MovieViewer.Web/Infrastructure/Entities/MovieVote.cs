using System.ComponentModel.DataAnnotations;

namespace MovieViewer.Web.Infrastructure.Entities
{
    public class MovieVote
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int Value { get; set; }
    }
}
