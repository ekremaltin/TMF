namespace TMF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TMF.Models.Context.TmfContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; //içerisinde veri bulunan tablolarda da değişiklik yapılmasına izin veriyor.
            ContextKey = "TMF.Models.Context.TmfContext";
        }

        protected override void Seed(TMF.Models.Context.TmfContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
