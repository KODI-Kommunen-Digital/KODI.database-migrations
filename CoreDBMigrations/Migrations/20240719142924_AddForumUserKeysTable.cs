using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20240719142924)]
    public class AddForumUserKeysTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS forum_user_keys;
                 CREATE TABLE forum_user_keys(
                    id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    forumId int NOT NULL,
                    cityId int NOT NULL,
                    encryptedForumAesKey TEXT NOT NULL,
                    userKeyId int NOT NULL,
                    groupKeyVersion int NOT NULL DEFAULT 0,
                    createdAt DATETIME,
                    FOREIGN KEY (cityId) REFERENCES cities(id),
                    FOREIGN KEY (userKeyId) REFERENCES user_keys(id)
                );";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS forum_user_keys;";

            Execute.Sql(sql);
        }
    }
}
