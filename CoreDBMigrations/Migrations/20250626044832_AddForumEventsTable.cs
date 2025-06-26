using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250626044832)]
    public class AddForumEventsTable : Migration
    {
        public override void Up()
        {
            string sql =
                            @"CREATE TABLE `forum_events` (
                `id` int NOT NULL AUTO_INCREMENT,
                `userId` int DEFAULT NULL,
                `title` varchar(255) DEFAULT NULL,
                `place` varchar(255) DEFAULT NULL,
                `description` text,
                `address` varchar(255) DEFAULT NULL,
                `email` varchar(255) DEFAULT NULL,
                `phone` varchar(255) DEFAULT NULL,
                `website` text,
                `price` double DEFAULT NULL,
                `discountPrice` double DEFAULT NULL,
                `longitude` double DEFAULT NULL,
                `latitude` double DEFAULT NULL,
                `startDate` datetime DEFAULT NULL,
                `endDate` datetime DEFAULT NULL,
                `createdAt` datetime DEFAULT CURRENT_TIMESTAMP,
                `pdf` varchar(255) DEFAULT NULL,
                `expiryDate` datetime DEFAULT NULL,
                `updatedAt` datetime DEFAULT NULL,
                `zipcode` int DEFAULT NULL,
                `viewCount` int DEFAULT NULL,
                PRIMARY KEY (`id`),
                KEY `userId` (`userId`),
                FOREIGN KEY (`userId`) REFERENCES `users` (`id`) ON DELETE CASCADE
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS `forum_events`";

            Execute.Sql(sql);
        }
    }
} 