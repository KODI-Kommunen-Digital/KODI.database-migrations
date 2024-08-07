using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240325152524)]
    public class AddCardAccountTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS card_account CASCADE;
                CREATE TABLE card_account (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    status int,
                    userId int,
                    balance double,
                    FOREIGN KEY (userId) REFERENCES users(id)
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS card_account CASCADE;";

            Execute.Sql(sql);
        }
    }
}
