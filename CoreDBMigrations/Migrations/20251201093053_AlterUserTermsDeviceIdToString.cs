using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20251201120000)]
    public class AlterUserTermsDeviceIdToString : Migration
    {
        public override void Up()
        {
            string sql = @"
                ALTER TABLE user_terms DROP INDEX device_id;
                ALTER TABLE user_terms MODIFY COLUMN device_id VARCHAR(255) NOT NULL;
                ALTER TABLE user_terms ADD UNIQUE KEY (device_id, version_accepted);
            ";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = @"
                ALTER TABLE user_terms DROP INDEX device_id;
                ALTER TABLE user_terms MODIFY COLUMN device_id BIGINT NOT NULL;
                ALTER TABLE user_terms ADD UNIQUE KEY (device_id, version_accepted);
            ";
            Execute.Sql(sql);
        }
    }
}