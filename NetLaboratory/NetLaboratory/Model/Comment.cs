using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetLaboratory.Model
{
    [Table("sr13_228010_C")]
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        [Required]
        [ForeignKey("IdArticle")]
        public virtual Article Article { get; set; }
        public int IdArticle { get; set; }
    }
}