using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20260203100000)]
    public class AddMullkalenderPushDevicesTable : Migration
    {
        public override void Up()
        {
            string sql =
                @"CREATE TABLE IF NOT EXISTS mullkalender_push_devices (
                    id INT PRIMARY KEY AUTO_INCREMENT,
                    device_id VARCHAR(255) NOT NULL,
                    fcm_token VARCHAR(255) NOT NULL,
                    device_type VARCHAR(50) NOT NULL DEFAULT 'android',
                    app_version VARCHAR(20) NULL,
                    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                    is_active BOOLEAN DEFAULT TRUE,
                    
                    UNIQUE KEY unique_device_id (device_id),
                    UNIQUE KEY unique_fcm_token (fcm_token),
                    INDEX idx_is_active (is_active)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS mullkalender_push_devices;");
        }
    }
}
