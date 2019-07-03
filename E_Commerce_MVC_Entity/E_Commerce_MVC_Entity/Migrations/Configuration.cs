namespace E_Commerce_MVC_Entity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<E_Commerce_MVC_Entity.DAL.Commerce_context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "E_Commerce_MVC_Entity.DAL.Commerce_context";
        }

        protected override void Seed(E_Commerce_MVC_Entity.DAL.Commerce_context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
