using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250521112635)]
    public class RenameTimestampcolumn : Migration
    {
        public override void Up()
        {
            // Modify `message` column to explicitly allow NULL (if needed)
            // Add `parentId` column as a nullable foreign key
            string sql = @"ALTER TABLE listing_chats
                            CHANGE `timestamp` `createdAt` TIMESTAMP DEFAULT CURRENT_TIMESTAMP;
            ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = @"
                ALTER TABLE listing_chats
                CHANGE `createdAt` `timestamp` TIMESTAMP DEFAULT CURRENT_TIMESTAMP;
            ";
            Execute.Sql(sql);
        }
    }
}
