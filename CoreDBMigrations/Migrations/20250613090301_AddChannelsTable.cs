using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250613090301)]
    public class AddChannelsTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                CREATE TABLE `channels` (
                  `id` int NOT NULL AUTO_INCREMENT,
                  `name` varchar(100) NOT NULL,
                  `description` text,
                  `categoryId` int DEFAULT NULL,
                  `ownerId` int NOT NULL,
                  `status` enum('active','inactive') DEFAULT 'active',
                  `metadata` json DEFAULT NULL,
                  `createdAt` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
                  `updatedAt` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                  PRIMARY KEY (`id`),
                  KEY `categoryId` (`categoryId`),
                  KEY `ownerId` (`ownerId`),
                  CONSTRAINT `channels_ibfk_1` FOREIGN KEY (`categoryId`) REFERENCES `categories` (`id`) ON DELETE SET NULL,
                  CONSTRAINT `channels_ibfk_2` FOREIGN KEY (`ownerId`) REFERENCES `users` (`id`) ON DELETE CASCADE
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
            ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS `channels`;");
        }
    }
}
