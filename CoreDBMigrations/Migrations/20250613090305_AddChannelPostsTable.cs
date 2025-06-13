using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250613090305)]
    public class AddChannelPostsTable : Migration
    {
        public override void Up()
        {
            string sql = @"
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

            Execute.Sql(sql);
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS `channel_posts`;");
        }
    }
}
