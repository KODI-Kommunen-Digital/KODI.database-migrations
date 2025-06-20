using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250603130119)]
    public class AddStatusColumnToForumTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                ALTER TABLE `forums`
                ADD COLUMN `status` ENUM('active', 'inactive') NOT NULL DEFAULT 'active';
            ";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = @"
                ALTER TABLE `forums`
                DROP COLUMN `status`;
            ";
            Execute.Sql(sql);
        }
    }
}
