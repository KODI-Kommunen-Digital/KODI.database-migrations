using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20260602120003)]
    public class AddPhoneNumberToDefectReports : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE defect_reports
                    ADD COLUMN phone_number VARCHAR(20) NULL;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE defect_reports
                    DROP COLUMN phone_number;";

            Execute.Sql(sql);
        }
    }
}
