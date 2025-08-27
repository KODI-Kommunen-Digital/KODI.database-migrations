using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250827122947)]
    public class AddHeatStateTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS heat_state;
                CREATE TABLE heat_state (
                id INT AUTO_INCREMENT PRIMARY KEY,
                temperature FLOAT,
                grade VARCHAR(255) NOT NULL,
                text TEXT,
                last_updated DATETIME,
                fetched_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
            );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS heat_state;";

            Execute.Sql(sql);
        }
    }
}


