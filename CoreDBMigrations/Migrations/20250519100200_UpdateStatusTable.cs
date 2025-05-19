using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(202305190001)]
    public class UpdateStatusTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"UPDATE status 
                 SET name = CASE 
                     WHEN id = 1 THEN 'Approved'
                     WHEN id = 2 THEN 'Pending'
                     WHEN id = 3 THEN 'Feedback'
                 END;";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"UPDATE status 
                 SET name = CASE 
                     WHEN id = 1 THEN 'Active'
                     WHEN id = 2 THEN 'Inactive'
                     WHEN id = 3 THEN 'Pending'
                 END;";
            Execute.Sql(sql);
        }
    }
}
