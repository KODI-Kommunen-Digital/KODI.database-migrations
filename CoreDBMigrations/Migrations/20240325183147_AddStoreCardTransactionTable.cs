using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240325183147)]
    public class AddStoreCardTransactionTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS store_card_transaction CASCADE;
                CREATE TABLE store_card_transaction (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    cardId int,
                    accountId int,
                    amount double,
                    type int,
                    FOREIGN KEY (cardId) REFERENCES store_card(id) ON DELETE CASCADE,
                    FOREIGN KEY (accountId) REFERENCES card_account(id) ON DELETE CASCADE
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS store_card_transaction CASCADE;";

            Execute.Sql(sql);
        }
    }
}
