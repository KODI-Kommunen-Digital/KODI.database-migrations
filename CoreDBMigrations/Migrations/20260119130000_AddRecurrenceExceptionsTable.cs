using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20260119130000)]
    public class AddRecurrenceExceptionsTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS listings_recurrence_exceptions;
                CREATE TABLE IF NOT EXISTS listings_recurrence_exceptions (
                id INT AUTO_INCREMENT PRIMARY KEY,
                recurrenceRuleId INT NOT NULL,
                exceptionDate DATE NOT NULL,
                reason VARCHAR(255) DEFAULT NULL,
                createdAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                FOREIGN KEY (recurrenceRuleId) REFERENCES listings_recurrence_rules(id) ON DELETE CASCADE,
                UNIQUE KEY unique_exception (recurrenceRuleId, exceptionDate)
            );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS listings_recurrence_exceptions;";

            Execute.Sql(sql);
        }
    }
}
