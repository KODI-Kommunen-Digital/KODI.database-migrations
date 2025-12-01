using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20251201055559)]
    public class AddUserTermsTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                    CREATE TABLE user_terms (
                    id BIGINT AUTO_INCREMENT PRIMARY KEY,
                    device_id BIGINT NOT NULL,
                    version_accepted INT NOT NULL,
                    accepted_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                    UNIQUE KEY (device_id, version_accepted),
                    FOREIGN KEY (version_accepted) REFERENCES privacy_policy(version)
                    );
                ";
            Execute.Sql(sql);
        }

        public override void Down()
        {
           string sql =
               @"DROP TABLE IF EXISTS user_terms";
            Execute.Sql(sql);
        }
    }
}
