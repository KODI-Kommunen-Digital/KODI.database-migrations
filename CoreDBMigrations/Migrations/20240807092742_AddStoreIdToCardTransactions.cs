using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20240807092742)]
    public class AddStoreIdToCardTransactions : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE store_card_transaction ADD storeId int,
               ADD CONSTRAINT FK_Store_Transaction_Store FOREIGN KEY (storeId) REFERENCES shops(id);";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE store_card_transaction DROP CONSTRAINT FK_Store_Transaction_Store;
                 ALTER TABLE store_card_transaction DROP COLUMN storeId;";

            Execute.Sql(sql);
        }
    }
}
