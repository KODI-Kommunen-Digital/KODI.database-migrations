using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240214152835)]
    public class AddShelvesTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS shelves;
                CREATE TABLE shelves (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    shopId int,
                    productId int,
                    title varchar(255),
                    description varchar(255),
                    FOREIGN KEY (shopId) REFERENCES shops(id) ON DELETE CASCADE,
                    FOREIGN KEY (productId) REFERENCES products(id) ON DELETE CASCADE
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS shelves;";

            Execute.Sql(sql);
        }
    }
}
