using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240214152918)]
    public class AddCartTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS cart CASCADE;
                CREATE TABLE cart (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    userId int,
                    shopId int,
                    FOREIGN KEY (userId) REFERENCES users(id),
                    FOREIGN KEY (shopId) REFERENCES shops(id) ON DELETE CASCADE
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS cart CASCADE;";

            Execute.Sql(sql);
        }
    }
}
