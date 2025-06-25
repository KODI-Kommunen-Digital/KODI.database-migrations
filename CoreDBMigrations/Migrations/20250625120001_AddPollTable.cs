using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250625120001)]
    public class AddFormChatPollTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"CREATE TABLE `forum_chat_polls` (
                `id` int NOT NULL AUTO_INCREMENT,
                `chatMessageId` int NOT NULL,
                `allowMultipleVotes` tinyint(1) NOT NULL DEFAULT '0',
                `createdAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
                PRIMARY KEY (`id`),
                UNIQUE KEY `chatMessageId_UNIQUE` (`chatMessageId`),
                FOREIGN KEY (`chatMessageId`) REFERENCES `forum_chat` (`id`) ON DELETE CASCADE
                )";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS `forum_chat_polls`";

            Execute.Sql(sql);
        }
    }
}
