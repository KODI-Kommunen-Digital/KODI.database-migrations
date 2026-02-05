using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20260203100002)]
    public class AddMullkalenderPushDeviceWasteTypesTable : Migration
    {
        public override void Up()
        {
            string sql =
                @"CREATE TABLE IF NOT EXISTS mullkalender_push_device_waste_types (
                    id INT PRIMARY KEY AUTO_INCREMENT,
                    device_street_id INT NOT NULL,
                    waste_type_id INT NOT NULL,
                    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    
                    FOREIGN KEY (device_street_id) REFERENCES mullkalender_push_device_streets(id) ON DELETE CASCADE,
                    UNIQUE KEY unique_device_street_waste (device_street_id, waste_type_id),
                    INDEX idx_waste_type (waste_type_id)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS mullkalender_push_device_waste_types;");
        }
    }
}
