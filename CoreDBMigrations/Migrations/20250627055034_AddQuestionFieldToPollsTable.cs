using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250627055034)]
    public class AddQuestionFieldToPollsTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE `forum_chat_polls` 
                ADD COLUMN `question` TEXT NOT NULL AFTER `chatMessageId`";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE `forum_chat_polls` 
                DROP COLUMN `question`";

            Execute.Sql(sql);
        }
    }
}
