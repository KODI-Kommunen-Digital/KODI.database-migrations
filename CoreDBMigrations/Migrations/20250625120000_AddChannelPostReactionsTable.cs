using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250625120000)]
    public class AddChannelPostReactionsTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"CREATE TABLE `channel_post_reactions` (
                `id` INT NOT NULL AUTO_INCREMENT,
                `postId` INT NOT NULL,
                `deviceToken` VARCHAR(255) NOT NULL,
                `reaction` VARCHAR(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
                `createdAt` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                PRIMARY KEY (`id`),
                UNIQUE KEY `unique_reaction_per_device` (`postId`, `deviceToken`),
                FOREIGN KEY (`postId`) REFERENCES `channel_posts` (`id`) ON DELETE CASCADE
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS `channel_post_reactions`;";

            Execute.Sql(sql);
        }
    }
}
