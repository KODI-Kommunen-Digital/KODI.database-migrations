using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20241015062613)]
    public class AddDefectReportsTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS defect_reports;
                CREATE TABLE defect_reports (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    userId INT NOT NULL,
                    title VARCHAR(255) NOT NULL,
                    description TEXT NOT NULL,
                    hashOfImage VARCHAR(255) NOT NULL,
                    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (userId) REFERENCES users(id) ON DELETE CASCADE
                );";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS defect_reports;";

            Execute.Sql(sql);
        }
    }
}
