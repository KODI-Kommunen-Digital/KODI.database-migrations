using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20240625094208)]
    public class AddUidColumnToStoreCard : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE store_card ADD uid VARCHAR(16) NOT NULL;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE store_card DROP COLUMN uid;";

            Execute.Sql(sql);
        }
    }
}
