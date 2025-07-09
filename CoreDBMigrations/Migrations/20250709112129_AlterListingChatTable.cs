using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250709112129)]
   public class AlterCreatedAtColumnToDatetimeInListingChats : Migration
    {
        public override void Up()
        {
            string sql = @"
                ALTER TABLE listing_chats
                MODIFY createdAt DATETIME DEFAULT CURRENT_TIMESTAMP;
            ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = @"
                ALTER TABLE listing_chats
                MODIFY createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP;
            ";

            Execute.Sql(sql);
        }
    }
} 