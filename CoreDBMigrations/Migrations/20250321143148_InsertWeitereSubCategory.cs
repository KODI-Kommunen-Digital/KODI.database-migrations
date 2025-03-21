using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20250321143148)]
    public class InsertWeitereSubCategory : Migration
    {
        public override void Up()
        {
            string sql =
               @"
                INSERT INTO subcategory (id, name, categoryId)
                VALUES
                    (21, 'Aufsichtsrat', 45);
                ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"
                DELETE FROM subcategory WHERE id = 21;
                ";
            Execute.Sql(sql);
        }
    }
}
