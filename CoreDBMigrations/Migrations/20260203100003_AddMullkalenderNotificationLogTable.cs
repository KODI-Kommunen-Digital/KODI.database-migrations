using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20260203100003)]
    public class AddMullkalenderNotificationLogTable : Migration
    {
        public override void Up()
        {
            string sql =
                @"CREATE TABLE IF NOT EXISTS mullkalender_notification_log (
                    id INT PRIMARY KEY AUTO_INCREMENT,
                    push_device_id INT NOT NULL COMMENT 'References mullkalender_push_devices.id',
                    city_id INT NOT NULL,
                    street_id INT NOT NULL,
                    pickup_date DATE NOT NULL,
                    waste_type_ids VARCHAR(100) NOT NULL COMMENT 'Comma-separated waste type IDs that were notified',
                    notification_body TEXT NULL COMMENT 'The notification message sent',
                    status ENUM('pending', 'sent', 'failed', 'skipped') DEFAULT 'pending',
                    retry_count INT DEFAULT 0,
                    error_message VARCHAR(500) NULL,
                    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    sent_at TIMESTAMP NULL,
                    
                    FOREIGN KEY (push_device_id) REFERENCES mullkalender_push_devices(id) ON DELETE CASCADE,
                    UNIQUE KEY unique_device_street_date (push_device_id, city_id, street_id, pickup_date),
                    INDEX idx_pickup_date (pickup_date),
                    INDEX idx_status (status),
                    INDEX idx_device (push_device_id),
                    INDEX idx_city_street_date (city_id, street_id, pickup_date)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS mullkalender_notification_log;");
        }
    }
}
