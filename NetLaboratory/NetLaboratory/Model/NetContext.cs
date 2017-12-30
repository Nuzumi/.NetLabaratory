using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLaboratory.Model
{
    public class NetContext : DbContext
    {
        public NetContext()
         : base("name=Context")
         {
         }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
        }


        public virtual IDbSet<Article> Articles { get; set; }
        public virtual IDbSet<Comment> Comments { get; set; }
    }
}
