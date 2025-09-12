using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20250909163200)]
    public class UpdateCityListingMappingStatus : Migration
    {
        public override void Up()
        {
            string sql = @"UPDATE city_listing_mappings clm
            JOIN listings l ON clm.listingId = l.id
            SET clm.status = l.statusId;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            
        }
    }
}