using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20260225090000)]
    public class AddUpdatedAtToForumChat : Migration
    {
        public override void Up()
        {
            string sql = @"
                ALTER TABLE `forum_chat`
                ADD COLUMN `updatedAt` datetime DEFAULT NULL AFTER `createdAt`;
            ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = @"
                ALTER TABLE `forum_chat`
                DROP COLUMN `updatedAt`;
            ";

            Execute.Sql(sql);
        }
    }
}
