using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20250305143733)]
    public class AddOrderColumnInCityListingMapping : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE city_listing_mappings ADD cityOrder int;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE city_listing_mappings DROP COLUMN cityOrder;";

            Execute.Sql(sql);
        }
    }
}