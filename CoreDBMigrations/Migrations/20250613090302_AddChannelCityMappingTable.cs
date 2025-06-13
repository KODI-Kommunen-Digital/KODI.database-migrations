using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250613090302)]
    public class AddChannelCityMappingTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                CREATE TABLE `channel_city_mapping` (
                  `channelId` int NOT NULL,
                  `cityId` int NOT NULL,
                  `status` int NOT NULL,
                  `message` text DEFAULT NULL,
                  `createdAt` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
                  `updatedAt` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                  PRIMARY KEY (`channelId`, `cityId`),
                  KEY `channelId` (`channelId`),
                  KEY `cityId` (`cityId`),
                  KEY `status` (`status`),
                  CONSTRAINT `channel_city_mapping_ibfk_1` FOREIGN KEY (`channelId`) REFERENCES `channels` (`id`) ON DELETE CASCADE,
                  CONSTRAINT `channel_city_mapping_ibfk_2` FOREIGN KEY (`cityId`) REFERENCES `cities` (`id`) ON DELETE CASCADE,
                  CONSTRAINT `channel_city_mapping_ibfk_3` FOREIGN KEY (`status`) REFERENCES `status` (`id`)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
            ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS `channel_city_mapping`;");
        }
    }
}
