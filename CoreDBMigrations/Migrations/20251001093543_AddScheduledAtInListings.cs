using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20251001093543)]
    public class AddScheduledAtInListings : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE listings ADD scheduledAt DATETIME;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE listings DROP COLUMN scheduledAt;";

            Execute.Sql(sql);
        }
    }
}