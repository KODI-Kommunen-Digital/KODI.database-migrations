using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20260409100001)]
    public class RemoveSeriesIdColumnListingsTable : Migration
    {
        public override void Up()
        {
            string sql =
                @"ALTER TABLE `listings`
                    DROP FOREIGN KEY `fk_listings_series`,
                    DROP COLUMN `seriesId`;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
                @"ALTER TABLE `listings`
                    ADD COLUMN `seriesId` INT DEFAULT NULL AFTER `categoryId`,
                    ADD CONSTRAINT `fk_listings_series`
                        FOREIGN KEY (`seriesId`) REFERENCES `event_category`(`id`)
                        ON DELETE SET NULL;";

            Execute.Sql(sql);
        }
    }
}
