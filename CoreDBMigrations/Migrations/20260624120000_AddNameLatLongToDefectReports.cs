using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20260624120000)]
    public class AddNameLatLongToDefectReports : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE defect_reports
                    ADD COLUMN name VARCHAR(255) NULL,
                    ADD COLUMN lat DECIMAL(10, 8) NULL,
                    ADD COLUMN `long` DECIMAL(11, 8) NULL;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE defect_reports
                    DROP COLUMN name,
                    DROP COLUMN lat,
                    DROP COLUMN `long`;";

            Execute.Sql(sql);
        }
    }
}
