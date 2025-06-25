using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250520123146)]
    public class AddColumnsToForumChats : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                ALTER TABLE forum_chat
                ADD COLUMN parentId INT NULL,
                ADD COLUMN fileUrl VARCHAR(255) NULL,
                ADD CONSTRAINT fk_forum_chat_parent FOREIGN KEY (parentId)
                    REFERENCES forum_chat(id) ON DELETE CASCADE;
            ");
        }

        public override void Down()
        {
            Execute.Sql(@"
                ALTER TABLE forum_chat
                DROP FOREIGN KEY fk_forum_chat_parent,
                DROP COLUMN parentId,
                DROP COLUMN fileUrl;
            ");
        }
    }
}