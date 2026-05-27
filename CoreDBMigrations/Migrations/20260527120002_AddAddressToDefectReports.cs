using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20260527120002)]
    public class AddAddressToDefectReports : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE defect_reports
                    ADD COLUMN address VARCHAR(500) NULL;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE defect_reports
                    DROP COLUMN address;";

            Execute.Sql(sql);
        }
    }
}
