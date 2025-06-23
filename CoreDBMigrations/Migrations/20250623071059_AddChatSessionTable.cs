using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250623071059)]
    public class AddChatSessionTable : Migration
    {
        public override void Up()
        {
            string sql = @"
               CREATE TABLE `user_chatbot_sessions` (
                    `id` INT AUTO_INCREMENT PRIMARY KEY,
                    `user_id` INT NOT NULL,
                    `session_name` VARCHAR(255) DEFAULT NULL, -- Optional: user can name a session
                    `created_at` DATETIME DEFAULT CURRENT_TIMESTAMP,
                    `updated_at` DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                    FOREIGN KEY (`user_id`) REFERENCES `users`(`id`) ON DELETE CASCADE
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
            ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = @"
               DROP TABLE IF EXISTS `user_chatbot_sessions`;
            ";

            Execute.Sql(sql);
        }
    }
}
