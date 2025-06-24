using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250624120000)]
    public class ModifyForumChatReactionColumn : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE `forum_chat_reactions` 
                MODIFY COLUMN `reaction` VARCHAR(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL;";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE `forum_chat_reactions` 
                MODIFY COLUMN `reaction` ENUM('like', 'dislike') NOT NULL;";

            Execute.Sql(sql);
        }
    }
}
