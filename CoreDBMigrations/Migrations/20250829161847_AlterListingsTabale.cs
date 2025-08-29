using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250829161847)]
    public class AddNotificationColumnsToListingsTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                ALTER TABLE `listings`
                ADD COLUMN `notification` TINYINT(1) NOT NULL DEFAULT 0,
                ADD COLUMN `reminderNotification` TINYINT(1) NOT NULL DEFAULT 0,
                ADD COLUMN `updatedNotification` TINYINT(1) NOT NULL DEFAULT 0;
            ";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = @"
                ALTER TABLE `listings`
                DROP COLUMN `notification`,
                DROP COLUMN `reminderNotification`,
                DROP COLUMN `updatedNotification`;
            ";
            Execute.Sql(sql);
        }
    }
}