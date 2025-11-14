using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20251113063712)]
    public class AddApprovalStatustoForumTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                ALTER TABLE `forums` ADD COLUMN `approval_status` ENUM('pending', 'approved', 'rejected') NOT NULL DEFAULT 'pending';
                ";
            Execute.Sql(sql);
        }

        public override void Down()
        {
           string sql =
               @"ALTER TABLE `forums` DROP COLUMN `approval_status`;";
            Execute.Sql(sql);
        }
    }
}
