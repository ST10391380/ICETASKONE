using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICETASKONE.Models
{
    public class RapMusic
    {
        public int Id { get; set; } // Unique identifier for each rap song

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Artist { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; } // (e.g., Rage, Trap Metal, Abstract Hip-Hop etc.)
        public int ReleaseYear { get; set; }
        public List<string> Keywords { get; set; } // List of keywords describing the song (e.g., motivational, party anthem, etc.)
    }
}
