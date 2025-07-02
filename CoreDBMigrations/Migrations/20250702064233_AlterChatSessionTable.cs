using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250702064233)]
    public class DropUserIdFromChatSession : Migration
    {
        public override void Up()
        {
            // Drop the foreign key constraint first
            Execute.Sql(@"
                ALTER TABLE `user_chatbot_sessions` 
                DROP FOREIGN KEY `user_chatbot_sessions_ibfk_1`;
            ");

            // Drop the `userId` column
            Execute.Sql(@"
                ALTER TABLE `user_chatbot_sessions` 
                DROP COLUMN `userId`;
            ");
        }

        public override void Down()
        {
            // Irreversible migration: leave this empty intentionally
        }
    }
}
