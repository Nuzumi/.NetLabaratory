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
        : base()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


        public virtual IDbSet<Article> Articles { get; set; }
        public virtual IDbSet<Comment> Comments { get; set; }
    }
}
