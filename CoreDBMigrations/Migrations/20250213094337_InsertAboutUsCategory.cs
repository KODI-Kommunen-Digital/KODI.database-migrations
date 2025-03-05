using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20250213094337)]
    public class InsertAboutUsCategory : Migration
    {
        public override void Up()
        {
            string sql =
               @"INSERT INTO categories (id, name, isEnabled, category_order)
                VALUES 
                    (47, 'Über Uns', false, 47)
                ON DUPLICATE KEY UPDATE
                    name = name,
                    isEnabled = true,
                    category_order = category_order;
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
