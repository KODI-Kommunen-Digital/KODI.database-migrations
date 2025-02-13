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
                    (46, 'Über Uns');
                INSERT INTO subcategory (id, name, categoryId)
                VALUES
                    (16, 'Ansprechpartner', 46),
                    (17, 'Projekte', 46),
                    (18, 'Events', 46),
                    (19, 'Gesellschafter', 46),
                    (20, 'Aufsichtsrat', 46);
                ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"
                DELETE FROM subcategory WHERE id IN (16, 17, 18, 19, 20);
                DELETE FROM categories WHERE id IN (46);
                ";
            Execute.Sql(sql);
        }
    }
}
