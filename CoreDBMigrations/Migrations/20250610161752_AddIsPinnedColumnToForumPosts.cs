using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250610161752)]
    public class AddIsPinnedColumnToForumPosts : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE forum_posts ADD COLUMN isPinned TINYINT(1) DEFAULT 0;
                
                -- Update existing posts to have isPinned = 0 if not already set
                UPDATE forum_posts SET isPinned = 0 WHERE isPinned IS NULL;
                
                -- Create index on isPinned column for better performance
                CREATE INDEX idx_forum_posts_pinned ON forum_posts(forumId, isPinned, createdAt);";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP INDEX IF EXISTS idx_forum_posts_pinned ON forum_posts;
                ALTER TABLE forum_posts DROP COLUMN isPinned;";

            Execute.Sql(sql);
        }
    }
}
