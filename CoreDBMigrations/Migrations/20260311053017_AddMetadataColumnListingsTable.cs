using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20260311053017)]
    public class AddMetadataColumnListingsTable : Migration
    {
        public override void Up()
        {
            string sql =
                @"ALTER TABLE `listings` ADD COLUMN `metadata` JSON DEFAULT NULL;";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
                @"ALTER TABLE `listings` DROP COLUMN `metadata`;";
            Execute.Sql(sql);
        }
    }
}
