using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20260122120000)]
    public class AddStartDateAndRepeatUntilToListingsRecurrenceRules : Migration
    {
        public override void Up()
        {
            string sql = @"
                ALTER TABLE listings_recurrence_rules 
                ADD COLUMN startDate DATETIME DEFAULT NULL,
                ADD COLUMN repeatUntil DATETIME DEFAULT NULL;
            ";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = @"
                ALTER TABLE listings_recurrence_rules 
                DROP COLUMN startDate,
                DROP COLUMN repeatUntil;
            ";
            Execute.Sql(sql);
        }
    }
}
