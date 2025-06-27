using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250627124754)]
    public class AddForumEventImagesTable : Migration
    {
        public override void Up()
        {
            string sql =
                            @"CREATE TABLE IF NOT EXISTS `forum_event_images` (
                `id` int NOT NULL AUTO_INCREMENT,
                `eventId` int NOT NULL,
                `imagePath` varchar(1000) NOT NULL,
                `originalName` varchar(255) DEFAULT NULL,
                `fileSize` int DEFAULT NULL,
                `mimeType` varchar(100) DEFAULT NULL,
                `imageOrder` int DEFAULT NULL,
                `createdAt` datetime DEFAULT CURRENT_TIMESTAMP,
                `updatedAt` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                PRIMARY KEY (`id`),
                KEY `eventId` (`eventId`),
                KEY `imageOrder` (`imageOrder`),
                CONSTRAINT `forum_event_images_ibfk_1` FOREIGN KEY (`eventId`) REFERENCES `forum_events` (`id`) ON DELETE CASCADE
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS `forum_event_images`";

            Execute.Sql(sql);
        }
    }
}
