using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240214154214)]
    public class AddProductRequestsTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS product_requests CASCADE;
                CREATE TABLE product_requests (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    title varchar(255),
                    description varchar(255),
                    requestType int,
                    sellerId int,
                    shopId int,
                    productId int,
                    price double,
                    count int,
                    threshold int,
                    maxCount int,
                    status int,
                    categoryId int,
                    subCategoryId int,
                    FOREIGN KEY (shopId) REFERENCES shops(id) ON DELETE CASCADE,
                    FOREIGN KEY (productId) REFERENCES products(id) ON DELETE CASCADE,
                    FOREIGN KEY (sellerId) REFERENCES sellers(id) ON DELETE CASCADE,
                    FOREIGN KEY (categoryId) REFERENCES store_categories(id) ON DELETE CASCADE,
                    FOREIGN KEY (subCategoryId) REFERENCES store_sub_categories(id) ON DELETE CASCADE

                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS product_requests CASCADE;";

            Execute.Sql(sql);
        }
    }
}
