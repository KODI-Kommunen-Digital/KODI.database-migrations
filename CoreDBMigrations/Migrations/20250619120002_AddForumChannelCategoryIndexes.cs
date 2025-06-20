using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250619120002)]
    public class AddForumChannelCategoryIndexes : Migration
    {
        public override void Up()
        {
            string sql = @"
                -- Add indexes for better query performance
                
                -- Index on forums for category-based queries
                CREATE INDEX idx_forums_category_status ON forums(categoryId, isPrivate);
                
                -- Index on channels for category-based queries  
                CREATE INDEX idx_channels_category_status ON channels(categoryId, status);
                
                -- Add unique constraint on forum_channel_categories name
                ALTER TABLE forum_channel_categories 
                ADD CONSTRAINT uk_forum_channel_categories_name UNIQUE (name);
                
                -- Add check constraint for valid type values (MySQL 8.0+)
                -- ALTER TABLE forum_channel_categories 
                -- ADD CONSTRAINT chk_category_type CHECK (type IN ('forum', 'channel', 'both'));
            ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = @"
                -- Remove indexes
                DROP INDEX IF EXISTS idx_forums_category_status ON forums;
                DROP INDEX IF EXISTS idx_channels_category_status ON channels;
                
                -- Remove unique constraint
                ALTER TABLE forum_channel_categories 
                DROP CONSTRAINT IF EXISTS uk_forum_channel_categories_name;
                
                -- Remove check constraint if it exists
                -- ALTER TABLE forum_channel_categories 
                -- DROP CONSTRAINT IF EXISTS chk_category_type;
            ";

            Execute.Sql(sql);
        }
    }
}
