using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250624120001)]
    public class AddFileMetadataToForumChat : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE `forum_chat` ADD COLUMN `fileMetadata` TEXT DEFAULT NULL;";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE `forum_chat` DROP COLUMN `fileMetadata`;";

            Execute.Sql(sql);
        }
    }
}
