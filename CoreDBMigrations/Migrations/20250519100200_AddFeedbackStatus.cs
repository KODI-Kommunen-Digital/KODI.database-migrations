using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250519100200)]
    public class AddFeedbackToStatusTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"INSERT INTO status (id, name) VALUES (4, ""Feedback"");";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = @"DELETE FROM services WHERE id = 4;";
            Execute.Sql(sql);
        }
    }
}