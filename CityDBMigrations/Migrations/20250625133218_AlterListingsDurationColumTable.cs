using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20250625133218)]
    public class AlterListingsDurationColumTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"
                 ALTER TABLE listings drop column duration;
                ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE listings add column duration varchar(20) CHECK (duration REGEXP '^[0-9]+[dhm]([0-9]+[dhm])*$');
                ";
            // not changing back to varchar(1000) because it's not guaranteed that the message will fit in 1000 characters after encryption.
            Execute.Sql(sql);
        }
    }
}