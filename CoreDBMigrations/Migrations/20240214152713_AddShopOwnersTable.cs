using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240214152713)]
    public class AddShopOwnersTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS shop_owners CASCADE;
                CREATE TABLE shop_owners (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    shopId int,
                    userId int,
                    FOREIGN KEY (shopId) REFERENCES shops(id) ON DELETE CASCADE,
                    FOREIGN KEY (userId) REFERENCES users(id)
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS shop_owners CASCADE;";

            Execute.Sql(sql);
        }
    }
}
