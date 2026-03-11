using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20260311100620)]
    public class AddSeriesIdColumnListingsTable : Migration
    {
        public override void Up()
        {
            string sql =
                @"ALTER TABLE `listings`
                    ADD COLUMN `seriesId` INT DEFAULT NULL AFTER `categoryId`,
                    ADD CONSTRAINT `fk_listings_series`
                        FOREIGN KEY (`seriesId`) REFERENCES `listing_series`(`id`)
                        ON DELETE SET NULL;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
                @"ALTER TABLE `listings`
                    DROP FOREIGN KEY `fk_listings_series`,
                    DROP COLUMN `seriesId`;";

            Execute.Sql(sql);
        }
    }
}
