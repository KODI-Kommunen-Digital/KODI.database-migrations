using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20241114080006)]
    public class InsertGastroJobborseCategories : Migration
    {
        public override void Up()
        {
            string sql =
               @"INSERT IGNORE INTO categories (id, name)
                VALUES
                    (43, 'Gastro'),
                    (44, 'Jobbörse');
                    ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
        }
    }
}
