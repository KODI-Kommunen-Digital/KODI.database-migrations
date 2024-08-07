using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240325183150)]
    public class AddStoreStoreCategoryMappingTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS store_store_categories_mapping CASCADE;
                CREATE TABLE store_store_categories_mapping (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    categoryId int,
                    shopId int,
                    FOREIGN KEY (categoryId) REFERENCES store_categories(id) ON DELETE CASCADE,
                    FOREIGN KEY (shopId) REFERENCES shops(id) ON DELETE CASCADE
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS store_store_categories_mapping CASCADE;";

            Execute.Sql(sql);
        }
    }
}
