using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20240719122421)]
    public class AddUserKeysTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS user_keys;
                 CREATE TABLE user_keys(
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    userId int NOT NULL,
                    publicKey TEXT NOT NULL,
                    createdAt DATETIME,
                    FOREIGN KEY (userId) REFERENCES users(id)
                );";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS user_keys;";

            Execute.Sql(sql);
        }
    }
}
