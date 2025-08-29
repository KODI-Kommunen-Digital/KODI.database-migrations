using FluentMigrator;
namespace CoreDBMigrations.Migrations
{
    [Migration(20241126080955)]
    public class AddListingMappingTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS city_listing_mappings;
                CREATE TABLE city_listing_mappings (
                    cityId INT,
                    listingId INT NOT NULL,
                    PRIMARY KEY (cityId, listingId),
                    FOREIGN KEY (cityId) REFERENCES cities(id) ON DELETE CASCADE,
                    FOREIGN KEY (listingId) REFERENCES listings(id) ON DELETE CASCADE
                );";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS city_listing_mappings;";

            Execute.Sql(sql);
        }
    }
}
