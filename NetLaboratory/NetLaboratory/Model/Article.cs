using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLaboratory.Model
{
    [Table("sr13_228010_A")]
    public class Article
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
