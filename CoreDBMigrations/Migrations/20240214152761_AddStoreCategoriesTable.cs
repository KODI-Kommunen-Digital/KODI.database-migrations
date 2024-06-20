using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240214152761)]
    public class AddStoreCategoriesTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS store_categories CASCADE;
                CREATE TABLE store_categories (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    name varchar(255),
                    description varchar(255),
                    image varchar(255)
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS store_categories CASCADE;";

            Execute.Sql(sql);
        }
    }
}
