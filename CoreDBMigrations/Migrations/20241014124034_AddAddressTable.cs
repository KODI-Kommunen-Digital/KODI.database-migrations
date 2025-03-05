using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20241014124034)]
    public class AddAddressTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS addresses;
               CREATE TABLE addresses (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    userId INT,
                    houseNumber VARCHAR(255),
                    street VARCHAR(255),
                    pincode INT,
                    city VARCHAR(255),
                    createdAt DATETIME,
                    FOREIGN KEY (userId) REFERENCES users(id) ON DELETE CASCADE
                );";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS addresses;";

            Execute.Sql(sql);
        }
    }
}
