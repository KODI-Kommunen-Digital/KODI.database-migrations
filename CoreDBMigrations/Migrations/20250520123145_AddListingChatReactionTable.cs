using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250519104313)]
    public class AddListingChatTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS listing_chat_reactions;
                CREATE TABLE `listing_chat_reactions` (
                id BIGINT NOT NULL AUTO_INCREMENT,
                chatId BIGINT NOT NULL,
                userId INT NOT NULL,
                reaction ENUM('like', 'dislike') NOT NULL,
                createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                PRIMARY KEY (`id`),
                UNIQUE KEY `unique_reaction_per_user` (`chatId`, `userId`),
                FOREIGN KEY (`chatId`) REFERENCES `listing_chats` (`id`) ON DELETE CASCADE,
                FOREIGN KEY (`userId`) REFERENCES `users` (`id`) ON DELETE CASCADE
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS listing_chat_reactions;";

            Execute.Sql(sql);
        }
    }
}
