using System.ComponentModel.DataAnnotations;

namespace Fringes.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public string Texter { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
