using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250625093758)]
    public class AddFormChatPollVotesTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"CREATE TABLE `forum_chat_poll_votes` (
                `id` int NOT NULL AUTO_INCREMENT,
                `pollOptionId` int NOT NULL,
                `userId` int NOT NULL,
                `createdAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
                PRIMARY KEY (`id`),
                UNIQUE KEY `unique_vote_per_user_per_option` (`pollOptionId`,`userId`),
                KEY `fk_vote_poll_option_idx` (`pollOptionId`),
                KEY `fk_vote_user_idx` (`userId`),
                FOREIGN KEY (`pollOptionId`) REFERENCES `forum_chat_poll_options` (`id`) ON DELETE CASCADE,
                FOREIGN KEY (`userId`) REFERENCES `users` (`id`) ON DELETE CASCADE
                ) ";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS `forum_chat_poll_votes`";

            Execute.Sql(sql);
        }
    }
}
