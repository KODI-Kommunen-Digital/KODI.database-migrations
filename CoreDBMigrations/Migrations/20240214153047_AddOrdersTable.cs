using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240214153047)]
    public class AddOrdersTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS orders CASCADE;
                CREATE TABLE orders (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    products JSON,
                    shopId int,
                    amount double,
                    userId int,
                    cartId int,
                    paymentId int,
                    discount double,
                    FOREIGN KEY (shopId) REFERENCES shops(id) ON DELETE CASCADE,
                    FOREIGN KEY (userId) REFERENCES users(id),
                    FOREIGN KEY (paymentId) REFERENCES payments(id) ON DELETE CASCADE,
                    FOREIGN KEY (cartId) REFERENCES cart(id) ON DELETE CASCADE
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS orders CASCADE;";

            Execute.Sql(sql);
        }
    }
}
