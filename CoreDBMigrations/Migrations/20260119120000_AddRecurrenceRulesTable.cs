using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20260119120000)]
    public class AddRecurrenceRulesTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS listings_recurrence_rules;
                CREATE TABLE IF NOT EXISTS listings_recurrence_rules (
                id INT AUTO_INCREMENT PRIMARY KEY,
                listingId INT NOT NULL,
                freq ENUM('Daily', 'Weekly', 'Monthly') NOT NULL,
                intervalValue INT NOT NULL DEFAULT 1,
                weekdays JSON DEFAULT NULL,
                startTime TIME NOT NULL,
                endTime TIME NOT NULL,
                dayOffset INT DEFAULT 0,
                createdAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                updatedAt DATETIME DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
                FOREIGN KEY (listingId) REFERENCES listings(id) ON DELETE CASCADE
            );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS listings_recurrence_rules;";

            Execute.Sql(sql);
        }
    }
}
