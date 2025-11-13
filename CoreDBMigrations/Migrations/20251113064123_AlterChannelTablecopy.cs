using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20251113064123)]
    public class AddApprovalStatustoChannelTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                ALTER TABLE `channels` ADD COLUMN `approval_status` ENUM('pending', 'approved', 'rejected') NOT NULL DEFAULT 'pending';
                ";
            Execute.Sql(sql);
        }

        public override void Down()
        {
           string sql =
               @"ALTER TABLE `channels` DROP COLUMN `approval_status`;";
            Execute.Sql(sql);
        }
    }
}
