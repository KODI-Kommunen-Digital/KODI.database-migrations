using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20240807071730)]
    public class AddPinCodeColumnToStoreCard : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE store_card ADD pincode VARCHAR(16) NOT NULL;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE store_card DROP COLUMN pincode;";

            Execute.Sql(sql);
        }
    }
}
