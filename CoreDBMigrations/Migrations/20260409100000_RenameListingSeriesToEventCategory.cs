using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20260409100000)]
    public class RenameListingSeriesToEventCategory : Migration
    {
        public override void Up()
        {
            string sql =
                @"RENAME TABLE `listing_series` TO `event_category`;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
                @"RENAME TABLE `event_category` TO `listing_series`;";

            Execute.Sql(sql);
        }
    }
}
