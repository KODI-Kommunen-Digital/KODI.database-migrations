using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250619120001)]
    public class UpdateForumChannelCategoryReferences : Migration
    {
        public override void Up()
        {
            // Simple approach: just update the data and add new constraints
            // We'll let the database handle any existing constraint issues
            
            // Set all forum and channel categoryId to default category
            Execute.Sql(@"
                UPDATE forums 
                SET categoryId = (SELECT id FROM forum_channel_categories WHERE name = 'Berufliche Vereine und Verbände' LIMIT 1);
            ");

            Execute.Sql(@"
                UPDATE channels 
                SET categoryId = (SELECT id FROM forum_channel_categories WHERE name = 'Berufliche Vereine und Verbände' LIMIT 1);
            ");

            // Add new foreign key constraints
            Execute.Sql(@"
                ALTER TABLE forums 
                ADD CONSTRAINT forums_category_fk 
                FOREIGN KEY (categoryId) REFERENCES forum_channel_categories(id) ON DELETE SET NULL;
            ");

            Execute.Sql(@"
                ALTER TABLE channels 
                ADD CONSTRAINT channels_category_fk 
                FOREIGN KEY (categoryId) REFERENCES forum_channel_categories(id) ON DELETE SET NULL;
            ");
        }

        public override void Down()
        {
            string sql = @"
                -- Remove new foreign key constraints
                ALTER TABLE forums DROP FOREIGN KEY IF EXISTS forums_category_fk;
                ALTER TABLE channels DROP FOREIGN KEY IF EXISTS channels_category_fk;

                -- Restore original foreign key constraints to categories table (if it exists)
                ALTER TABLE forums 
                ADD CONSTRAINT forums_ibfk_1 
                FOREIGN KEY (categoryId) REFERENCES categories(id) ON DELETE SET NULL;

                ALTER TABLE channels 
                ADD CONSTRAINT channels_ibfk_1 
                FOREIGN KEY (categoryId) REFERENCES categories(id) ON DELETE SET NULL;
            ";

            Execute.Sql(sql);
        }
    }
}
