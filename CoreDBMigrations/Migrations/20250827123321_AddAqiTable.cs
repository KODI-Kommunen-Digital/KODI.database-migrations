using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250827123321)]
    public class AddAqiStateTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS aqi_state;
                CREATE TABLE aqi_state (
                id INT AUTO_INCREMENT PRIMARY KEY,
                aqi FLOAT,
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
               @"DROP TABLE IF EXISTS aqi_state;";

            Execute.Sql(sql);
        }
    }
}


