using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250623071329)]
    public class AddUserChatTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                    CREATE TABLE `user_chatbot_chats` (
                    `id` INT AUTO_INCREMENT PRIMARY KEY,
                    `session_id` INT NOT NULL,
                    `sender` ENUM('user', 'bot') NOT NULL,
                    `message` TEXT NOT NULL,
                    `created_at` DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (`session_id`) REFERENCES `user_chatbot_sessions`(`id`) ON DELETE CASCADE
                );
            ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = @"
               DROP TABLE IF EXISTS `user_chatbot_chats`;
            ";

            Execute.Sql(sql);
        }
    }
}
