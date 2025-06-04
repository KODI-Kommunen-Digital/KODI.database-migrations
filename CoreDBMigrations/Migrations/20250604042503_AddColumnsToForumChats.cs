using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250520123146)]
    public class AddColumnsToForumChats : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE forum_chat
                ADD COLUMN parentId BIGINT NULL,
                ADD COLUMN fileUrl VARCHAR(255) NULL,
                ADD FOREIGN KEY (parentId) REFERENCES forum_chat(id) ON DELETE CASCADE;";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE forum_chat
                DROP FOREIGN KEY forum_chats_ibfk_2,
                DROP COLUMN parentId,
                DROP COLUMN fileUrl;";

            Execute.Sql(sql);
        }
    }
} 