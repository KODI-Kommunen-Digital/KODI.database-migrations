using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240325183151)]
    public class AddStoreStoreSubCategoryMappingTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS store_store_sub_categories_mapping CASCADE;
                CREATE TABLE store_store_sub_categories_mapping (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    subCategoryId int,
                    shopId int,
                    FOREIGN KEY (subCategoryId) REFERENCES store_sub_categories(id) ON DELETE CASCADE,
                    FOREIGN KEY (shopId) REFERENCES shops(id) ON DELETE CASCADE
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS store_store_sub_categories_mapping CASCADE;";

            Execute.Sql(sql);
        }
    }
}
