namespace NetLaboratory.Migrations
{
    using NetLaboratory.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NetLaboratory.Model.NetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NetLaboratory.Model.NetContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Articles.AddOrUpdate(i => i.Id, new Article { Title = "Wa¿ny tytu³", Content = "Ciekawa treœæ", DayCreated = DateTime.Now });
        }
    }
}
