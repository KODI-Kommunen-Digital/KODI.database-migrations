using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20241216094108)]
    public class InsertDienstleisterCategory : Migration
    {
        public override void Up()
        {
            string sql =
               @"INSERT INTO categories (id, name, isEnabled, category_order)
                VALUES 
                    (45, 'Dienstleister', false, 45)
                ON DUPLICATE KEY UPDATE
                    name = name,
                    isEnabled = true,
                    category_order = category_order;
                INSERT INTO subcategory (id, name, categoryId)
                VALUES
                    (12, 'Handwerk', 45),
                    (13, 'Gesundheit', 45),
                    (14, 'Immobilien', 45),
                    (15, 'Finanzen', 45);
                ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"
                DELETE FROM subcategory WHERE id IN (12, 13, 14, 15);
                DELETE FROM categories WHERE id IN (45);
                ";
            Execute.Sql(sql);


        }
    }
}
