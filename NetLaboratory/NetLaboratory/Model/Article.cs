using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLaboratory.Model
{
    public class Article
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5), MaxLength(50, ErrorMessage = "Tytul musi być dłuższy niż 5 znaków i krótszy niż 50!")]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
