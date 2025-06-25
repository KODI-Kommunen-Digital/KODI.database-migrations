using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250625093640)]
    public class AddFormChatPollOptionsTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"CREATE TABLE `forum_chat_poll_options` (
                `id` int NOT NULL AUTO_INCREMENT,
                `pollId` int NOT NULL,
                `optionText` varchar(255) NOT NULL,
                PRIMARY KEY (`id`),
                KEY `fk_option_poll_idx` (`pollId`),
                FOREIGN KEY (`pollId`) REFERENCES `forum_chat_polls` (`id`) ON DELETE CASCADE
                ) ";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS `forum_chat_poll_options`";

            Execute.Sql(sql);
        }
    }
}
