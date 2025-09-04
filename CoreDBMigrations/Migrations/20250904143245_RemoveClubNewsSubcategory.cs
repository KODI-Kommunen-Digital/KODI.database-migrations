using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20250904143245)]
    public class RemoveClubNewsSubcategory : Migration
    {
        public override void Up()
        {
            string sql =
               @"
                DELETE FROM subcategory
                WHERE id = 8 AND name = 'Club News' AND categoryId = 1;
                ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"
                INSERT INTO subcategory (id, name, categoryId)
                VALUES (8, 'Club News', 1);
                ";
            
            Execute.Sql(sql);
        }
    }
}
