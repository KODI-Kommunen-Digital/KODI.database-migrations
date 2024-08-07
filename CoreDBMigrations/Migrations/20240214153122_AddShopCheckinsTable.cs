using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240214153122)]
    public class AddShopCheckinsTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS shopcheckins CASCADE;
                CREATE TABLE shopcheckins (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    shopId int,
                    userId int,
                    startTime DATETIME,
                    endTime DATETIME,
                    FOREIGN KEY (shopId) REFERENCES shops(id) ON DELETE CASCADE,
                    FOREIGN KEY (userId) REFERENCES users(id)
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS shopcheckins CASCADE;";

            Execute.Sql(sql);
        }
    }
}
