using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20241114080006)]
    public class InsertGastroJobborseCategories : Migration
    {
        public override void Up()
        {
            string sql =
               @"INSERT INTO categories (id, name, isEnabled, category_order)
                VALUES 
                    (43, 'Gastro', false, 43),
                    (44, 'Jobbörse', false, 44)
                ON DUPLICATE KEY UPDATE
                    name = name,
                    isEnabled = true,
                    category_order = category_order;
                ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
        }
    }
}
