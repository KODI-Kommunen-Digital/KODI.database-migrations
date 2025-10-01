using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20251001093239)]
    public class AddScheduleStatus : Migration
    {
        public override void Up()
        {
            string sql =
               @"INSERT INTO status (id, name) VALUES (4, 'Scheduled');";

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