using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240214152759)]
    public class AddSellersTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS sellers CASCADE;
                CREATE TABLE sellers (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT, 
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    shopId int,
                    userId int,
                    description varchar(255),
                    title varchar(255),
                    status int,
                    paymentOwed double,
                    FOREIGN KEY (shopId) REFERENCES shops(id) ON DELETE CASCADE,
                    FOREIGN KEY (userId) REFERENCES users(id)
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS sellers CASCADE;";

            Execute.Sql(sql);
        }
    }
}
