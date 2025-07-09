using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20250709101854)]
    public class UpdateForumChatSenderIdOnDeleteSetNull : Migration
    {
        public override void Up()
        {
            string sql = @"
                -- 1. Make senderId nullable
                ALTER TABLE forum_chat
                MODIFY senderId INT NULL;


                -- 2. Add FK with ON DELETE SET NULL
                ALTER TABLE forum_chat
                ADD CONSTRAINT fk_forum_chat_sender
                FOREIGN KEY (senderId) REFERENCES users(id) ON DELETE SET NULL;
            ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
           
        }
    }
}
