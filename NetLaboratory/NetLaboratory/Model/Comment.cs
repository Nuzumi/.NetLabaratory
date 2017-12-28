using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetLaboratory.Model
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [ MaxLength(200, ErrorMessage = "Komentarz musi mieć do 200 znaków!")]
        public string Content { get; set; }
        [Required]
        public DateTime DayCreated { get; set; }

        [Required]
        [ForeignKey("IdArticle")]
        public virtual Article Article { get; set; }
        public int IdArticle { get; set; }
    }
}