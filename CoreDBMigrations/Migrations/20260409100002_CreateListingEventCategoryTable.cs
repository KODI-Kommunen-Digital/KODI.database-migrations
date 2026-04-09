using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20260409100002)]
    public class CreateListingEventCategoryTable : Migration
    {
        public override void Up()
        {
            string sql =
                @"CREATE TABLE `listing_event_category` (
                    `id` INT NOT NULL AUTO_INCREMENT,
                    `listingId` INT NOT NULL,
                    `eventCategoryId` INT NOT NULL,
                    PRIMARY KEY (`id`),
                    UNIQUE KEY `uq_listing_event_category` (`listingId`, `eventCategoryId`),
                    CONSTRAINT `fk_lec_listing`
                        FOREIGN KEY (`listingId`) REFERENCES `listings`(`id`)
                        ON DELETE CASCADE,
                    CONSTRAINT `fk_lec_event_category`
                        FOREIGN KEY (`eventCategoryId`) REFERENCES `event_category`(`id`)
                        ON DELETE CASCADE
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
                @"DROP TABLE IF EXISTS `listing_event_category`;";

            Execute.Sql(sql);
        }
    }
}
