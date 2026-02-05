using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20260203100001)]
    public class AddMullkalenderPushDeviceStreetsTable : Migration
    {
        public override void Up()
        {
            string sql =
                @"CREATE TABLE IF NOT EXISTS mullkalender_push_device_streets (
                    id INT PRIMARY KEY AUTO_INCREMENT,
                    push_device_id INT NOT NULL COMMENT 'References mullkalender_push_devices.id',
                    city_id INT NOT NULL,
                    street_id INT NOT NULL,
                    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                    is_active BOOLEAN DEFAULT TRUE,
                    
                    FOREIGN KEY (push_device_id) REFERENCES mullkalender_push_devices(id) ON DELETE CASCADE,
                    UNIQUE KEY unique_device (push_device_id),
                    INDEX idx_city_street (city_id, street_id),
                    INDEX idx_is_active (is_active)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS mullkalender_push_device_streets;");
        }
    }
}
