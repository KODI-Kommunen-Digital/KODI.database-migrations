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
                    `userId` INT NOT NULL,
                    `name` VARCHAR(255) DEFAULT NULL, -- Optional: user can name a session
                    `createdAt` DATETIME DEFAULT CURRENT_TIMESTAMP,
                    `updatedAt` DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                    FOREIGN KEY (`userId`) REFERENCES `users`(`id`) ON DELETE CASCADE
                );
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
