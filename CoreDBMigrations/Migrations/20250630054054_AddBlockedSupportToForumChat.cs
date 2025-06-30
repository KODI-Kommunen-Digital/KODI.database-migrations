using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250630054054)]
    public class AddBlockedMessageSupport : Migration
    {
        public override void Up()
        {
            string sql = @"
                ALTER TABLE `forum_chat` 
                ADD COLUMN `isBlocked` BOOLEAN NOT NULL DEFAULT FALSE
            ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = @"
                ALTER TABLE `forum_chat` 
                DROP COLUMN `isBlocked`
                ";

            Execute.Sql(sql);
        }
    }
}
