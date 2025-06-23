using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20250623104325)]
    public class AlterListingsTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"
                 ALTER TABLE listings add column isAllDayEvent boolean NOT NULL DEFAULT FALSE;
                ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE listings drop column isAllDayEvent;
                ";
            // not changing back to varchar(1000) because it's not guaranteed that the message will fit in 1000 characters after encryption.
            Execute.Sql(sql);
        }
    }
}