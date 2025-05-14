using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20230514000100)]
    public class AddFeedbackStatus : Migration
    {
        public override void Up()
        {
            string sql =
               @"INSERT INTO status (id, name) VALUES (4, 'Feedback');";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DELETE FROM status WHERE id = 4;";
            Execute.Sql(sql);
        }
    }
}
