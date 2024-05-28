using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfumeryStore.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid UserId { get; init; }
        [Required]
        public string ReviewText { get; set; } = string.Empty;
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime InsertedDate { get; set; }
    }
}
