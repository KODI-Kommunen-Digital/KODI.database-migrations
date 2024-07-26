using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20240719100607)]
    public class AlterForumChatTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"
                 ALTER TABLE forum_chat add column groupKeyVersion int NOT NULL DEFAULT 0; -- 0 -> public chat
                 ALTER TABLE forum_chat change column message message TEXT;
                ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE forum_chat drop column groupKeyVersion;
                ";
            // not changing back to varchar(1000) because it's not guaranteed that the message will fit in 1000 characters after encryption.
            Execute.Sql(sql);
        }
    }
}
