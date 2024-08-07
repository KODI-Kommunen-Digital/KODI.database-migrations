using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240620121329)]
    public class AddShopsSecretKeysTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS shops_secret_keys CASCADE;
                CREATE TABLE shops_secret_keys (
                    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                    shopId INT,
                    encryptionKey VARCHAR(64),
                    encryptionIv VARCHAR(32),
                    CONSTRAINT UC_ShopId UNIQUE (shopId),
                    FOREIGN KEY (shopId) REFERENCES shops(id) ON DELETE CASCADE
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS shops_secret_keys CASCADE;";

            Execute.Sql(sql);
        }
    }
}
