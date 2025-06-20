using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250619120000)]
    public class CreateForumChannelCategoriesTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                -- Create forum_channel_categories table
                CREATE TABLE `forum_channel_categories` (
                  `id` int NOT NULL AUTO_INCREMENT,
                  `name` varchar(255) NOT NULL,
                  `description` text DEFAULT NULL,
                  `isActive` tinyint(1) DEFAULT 1,
                  `displayOrder` int DEFAULT 0,
                  `createdAt` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
                  `updatedAt` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                  PRIMARY KEY (`id`),
                  KEY `idx_active_order` (`isActive`, `displayOrder`)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

                -- Insert default categories for forums and channels
                INSERT INTO `forum_channel_categories` (`name`, `description`, `isActive`, `displayOrder`) VALUES
                ('Berufliche Vereine und Verbände', 'Kategorien für berufsbezogene Vereine und Verbände', 1, 1),
                ('Internationale Vereine', 'Kategorien für internationale Vereinigungen', 1, 2),
                ('Kunst, Kultur und Geschichte', 'Kategorien für kulturelle, künstlerische und historische Vereine', 1, 3),
                ('Narrenzunfte und -gruppen', 'Kategorien für Karnevalsvereine und Narrenzünfte', 1, 4),
                ('Musik', 'Kategorien für Musikvereine und -gruppen', 1, 5),
                ('Parteien und Wählervereinigungen', 'Kategorien für politische Parteien und Wählergruppen', 1, 6),
                ('Schule und Bildung', 'Kategorien für Bildungseinrichtungen und Schulvereine', 1, 7),
                ('Soziales und Hilfsdienste', 'Kategorien für soziale Vereine und Hilfsorganisationen', 1, 8),
                ('Sport', 'Kategorien für Sportvereine und -gruppen', 1, 9),
                ('Touristische Vereine und Verbände', 'Kategorien für touristische und Fremdenverkehrsvereine', 1, 10),
                ('Umwelt und Naturschutz', 'Kategorien für Umwelt- und Naturschutzorganisationen', 1, 11);
            ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS `forum_channel_categories`;");
        }
    }
}
