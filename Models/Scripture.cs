using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }

        [DataType(DataType.Date)]
        public DateTime Accessed { get; set; }

        public string Notes { get; set; }
    }
}
