using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250213094337)]
    public class InsertAboutUsCategory : Migration
    {
        public override void Up()
        {
            string sql =
               @"INSERT INTO categories (id, name)
                VALUES 
                    (47, 'Über Uns');
                INSERT INTO subcategory (id, name, categoryId)
                VALUES
                    (16, 'Ansprechpartner', 47),
                    (17, 'Projekte', 47),
                    (18, 'Events', 47),
                    (19, 'Gesellschafter', 47),
                    (20, 'Aufsichtsrat', 47);
                ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"
                DELETE FROM subcategory WHERE id IN (16, 17, 18, 19, 20);
                DELETE FROM categories WHERE id IN (47);
                ";
            Execute.Sql(sql);
        }
    }
}
