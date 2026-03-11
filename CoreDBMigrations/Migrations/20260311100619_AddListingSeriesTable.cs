using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20260311100619)]
    public class AddListingSeriesTable : Migration
    {
        public override void Up()
        {
            string sql =
                @"CREATE TABLE `listing_series` (
                    `id` INT NOT NULL AUTO_INCREMENT,
                    `seriesName` VARCHAR(255) NOT NULL,
                    `externalSeriesId` INT DEFAULT NULL,
                    PRIMARY KEY (`id`),
                    UNIQUE KEY `uq_series_name` (`seriesName`)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
                @"DROP TABLE IF EXISTS `listing_series`;";

            Execute.Sql(sql);
        }
    }
}
