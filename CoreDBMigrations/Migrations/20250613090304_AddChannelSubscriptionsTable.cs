using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250613090304)]
    public class AddChannelSubscriptionsTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                CREATE TABLE `channel_subscriptions` (
                  `id` int NOT NULL AUTO_INCREMENT,
                  `channelId` int NOT NULL,
                  `userId` int DEFAULT NULL,
                  `deviceToken` varchar(255) DEFAULT NULL,
                  `subscribedAt` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
                  `notificationsEnabled` tinyint(1) DEFAULT '1',
                  `isActive` tinyint(1) DEFAULT '1',
                  PRIMARY KEY (`id`),
                  KEY `channelId` (`channelId`),
                  KEY `userId` (`userId`),
                  CONSTRAINT `channel_subscriptions_ibfk_1` FOREIGN KEY (`channelId`) REFERENCES `channels` (`id`) ON DELETE CASCADE,
                  CONSTRAINT `channel_subscriptions_ibfk_2` FOREIGN KEY (`userId`) REFERENCES `users` (`id`) ON DELETE CASCADE
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
            ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS `channel_subscriptions`;");
        }
    }
}
