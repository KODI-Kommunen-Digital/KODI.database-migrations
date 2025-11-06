using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20250909142200)]
    public class UpdateCityListiingMapping : Migration
    {
        public override void Up()
        {
            string sql = @"ALTER TABLE `city_listing_mappings`
                ADD COLUMN `status` INT NOT NULL DEFAULT 2,
                ADD CONSTRAINT `city_listing_mappings_fk_status`
                FOREIGN KEY (`status`) REFERENCES `status`(`id`);
                ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            Execute.Sql(@"ALTER TABLE `city_listing_mappings`
                DROP COLUMN `status`;");
        }
    }
}