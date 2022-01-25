using CsIO.Infra.Data.Context;
using System.Data.Entity.Migrations;

namespace CsIO.Infra.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CsIoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}
