namespace NetLaboratory.Migrations
{
    using NetLaboratory.Model;
    using System;
    using System.Collections.Generic;
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
            context.Articles.AddOrUpdate(i => i.Id, new Article
            {
                Title = "Je¿e przysz³oœci¹ narodu",
                Content = "Do opracowania w innym terminie",
                Comments = new List<Comment>
                {
                    new Comment
                    {
                        Content = "Kiedy artykul zostanie dodany?"
                    },
                    new Comment
                    {
                        Content = "Temat jest zbyt kontrowersyjny!"
                    }
                }
            });
        }
    }
}
