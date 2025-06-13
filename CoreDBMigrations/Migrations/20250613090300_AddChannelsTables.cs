using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250613090300)]
    public class AddChannelsTables : Migration
    {
        public override void Up()
        {
            // 1. Create channels table
            string createChannelsTable = @"
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

            // 2. Create channel_city_mapping table
            string createChannelCityMappingTable = @"
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

            // 3. Create channel_admins table
            string createChannelAdminsTable = @"
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

            // 4. Create channel_subscriptions table
            string createChannelSubscriptionsTable = @"
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

            // 5. Create channel_posts table
            string createChannelPostsTable = @"
                CREATE TABLE `channel_posts` (
                  `id` int NOT NULL AUTO_INCREMENT,
                  `channelId` int NOT NULL,
                  `authorId` int NOT NULL,
                  `title` varchar(255) DEFAULT NULL,
                  `content` text NOT NULL,
                  `mediaUrls` json DEFAULT NULL,
                  `linkedEventId` int DEFAULT NULL,
                  `linkedWebsites` json DEFAULT NULL,
                  `isPublished` tinyint(1) DEFAULT '1',
                  `publishedAt` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
                  `createdAt` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
                  `updatedAt` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                  PRIMARY KEY (`id`),
                  KEY `channelId` (`channelId`),
                  KEY `authorId` (`authorId`),
                  KEY `linkedEventId` (`linkedEventId`),
                  CONSTRAINT `channel_posts_ibfk_1` FOREIGN KEY (`channelId`) REFERENCES `channels` (`id`) ON DELETE CASCADE,
                  CONSTRAINT `channel_posts_ibfk_2` FOREIGN KEY (`authorId`) REFERENCES `users` (`id`) ON DELETE CASCADE,
                  CONSTRAINT `channel_posts_ibfk_3` FOREIGN KEY (`linkedEventId`) REFERENCES `listings` (`id`) ON DELETE SET NULL
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
            ";

            Execute.Sql(createChannelsTable);
            Execute.Sql(createChannelCityMappingTable);
            Execute.Sql(createChannelAdminsTable);
            Execute.Sql(createChannelSubscriptionsTable);
            Execute.Sql(createChannelPostsTable);
        }

        public override void Down()
        {
            // Drop tables in reverse order to avoid foreign key constraint issues
            Execute.Sql("DROP TABLE IF EXISTS `channel_posts`;");
            Execute.Sql("DROP TABLE IF EXISTS `channel_subscriptions`;");
            Execute.Sql("DROP TABLE IF EXISTS `channel_admins`;");
            Execute.Sql("DROP TABLE IF EXISTS `channel_city_mapping`;");
            Execute.Sql("DROP TABLE IF EXISTS `channels`;");
        }
    }
}
