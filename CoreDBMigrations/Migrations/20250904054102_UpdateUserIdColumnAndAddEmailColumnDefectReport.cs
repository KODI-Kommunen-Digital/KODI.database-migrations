using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20250904054102)]
    public class UpdateUserIdColumnAndAddEmailColumnDefectReport : Migration
    {
        public override void Up()
        {
            string sql =
               @"
                ALTER TABLE defect_reports
                    MODIFY COLUMN userId INT NULL,
                    ADD COLUMN email VARCHAR(255);
                ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"
                ALTER TABLE defect_reports
                    MODIFY COLUMN userId INT NOT NULL,
                    DROP COLUMN email;
                ";
            Execute.Sql(sql);
        }
    }
}