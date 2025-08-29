using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250520120027)]
    public class AddParentIdToListingChatTable : Migration
    {
        public override void Up()
        {
            // Modify `message` column to explicitly allow NULL (if needed)
            // Add `parentId` column as a nullable foreign key
            string sql = @"
                ALTER TABLE listing_chats 
                MODIFY COLUMN message TEXT NULL,
                ADD COLUMN parentId BIGINT NULL,
                ADD COLUMN fileUrl  TEXT,
                ADD CONSTRAINT FK_listing_chats_parent 
                    FOREIGN KEY (parentId) REFERENCES listing_chats(id) ON DELETE SET NULL;
            ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = @"
                ALTER TABLE listing_chats 
                DROP FOREIGN KEY FK_listing_chats_parent,
                DROP COLUMN parentId,
                DROP COLUMN fileUrl;
            ";

            Execute.Sql(sql);
        }
    }
}
