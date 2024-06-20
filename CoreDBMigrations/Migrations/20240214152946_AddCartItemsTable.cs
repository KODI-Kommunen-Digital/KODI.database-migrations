using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240214152946)]
    public class AddCartItemsTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS cartitems CASCADE;
                CREATE TABLE cartitems (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    cartId int,
                    productId int,
                    quantity int,
                    pricePerQuantity double,
                    FOREIGN KEY (cartId) REFERENCES cart(id) ON DELETE CASCADE,
                    FOREIGN KEY (productId) REFERENCES products(id) ON DELETE CASCADE
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS cartitems CASCADE;";

            Execute.Sql(sql);
        }
    }
}
