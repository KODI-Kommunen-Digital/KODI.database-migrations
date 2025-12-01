using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20251201055307)]
    public class AddTermsTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                    CREATE TABLE privacy_policy (
                    id BIGINT AUTO_INCREMENT PRIMARY KEY,
                    version INT NOT NULL UNIQUE,
                    content LONGTEXT,
                    is_active BOOLEAN NOT NULL DEFAULT FALSE,
                    created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
                );
                ";
            Execute.Sql(sql);
        }

        public override void Down()
        {
           string sql =
               @"DROP TABLE IF EXISTS privacy_policy";
            Execute.Sql(sql);
        }
    }
}
