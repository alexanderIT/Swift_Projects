namespace VersionControlSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VersionControlSystem.VCSDBContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;

            ContextKey = "VersionControlSystem.VCSDBContext";
        }

        protected override void Seed(VersionControlSystem.VCSDBContext context)
        {

        }
    }
}
