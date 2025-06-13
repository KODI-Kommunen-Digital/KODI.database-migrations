using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250613090303)]
    public class AddChannelAdminsTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                CREATE TABLE `channel_admins` (
                  `id` int NOT NULL AUTO_INCREMENT,
                  `channelId` int NOT NULL,
                  `userId` int NOT NULL,
                  `assignedBy` int NOT NULL,
                  `assignedAt` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
                  `isActive` tinyint(1) DEFAULT '1',
                  PRIMARY KEY (`id`),
                  UNIQUE KEY `unique_channel_user` (`channelId`, `userId`),
                  KEY `channelId` (`channelId`),
                  KEY `userId` (`userId`),
                  KEY `assignedBy` (`assignedBy`),
                  CONSTRAINT `channel_admins_ibfk_1` FOREIGN KEY (`channelId`) REFERENCES `channels` (`id`) ON DELETE CASCADE,
                  CONSTRAINT `channel_admins_ibfk_2` FOREIGN KEY (`userId`) REFERENCES `users` (`id`) ON DELETE CASCADE,
                  CONSTRAINT `channel_admins_ibfk_3` FOREIGN KEY (`assignedBy`) REFERENCES `users` (`id`) ON DELETE CASCADE
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
            ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS `channel_admins`;");
        }
    }
}
