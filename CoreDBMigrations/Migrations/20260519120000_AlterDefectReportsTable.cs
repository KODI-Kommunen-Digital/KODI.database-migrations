using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20260519120000)]
    public class AlterDefectReportsTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE defect_reports
                    DROP FOREIGN KEY defect_reports_ibfk_1,
                    MODIFY COLUMN userId INT NULL,
                    MODIFY COLUMN hashOfImage VARCHAR(255) NULL,
                    ADD COLUMN email VARCHAR(255) NULL AFTER userId;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE defect_reports
                    DROP COLUMN email,
                    MODIFY COLUMN hashOfImage VARCHAR(255) NOT NULL,
                    MODIFY COLUMN userId INT NOT NULL,
                    ADD CONSTRAINT defect_reports_ibfk_1 FOREIGN KEY (userId) REFERENCES users(id) ON DELETE CASCADE;";

            Execute.Sql(sql);
        }
    }
}
