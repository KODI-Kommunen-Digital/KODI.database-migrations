using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20250707000000)]
    public class UpdateForumUserKeysUserKeyForeignKey : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE forum_user_keys DROP FOREIGN KEY forum_user_keys_ibfk_2;
                 ALTER TABLE forum_user_keys ADD CONSTRAINT forum_user_keys_ibfk_2 
                 FOREIGN KEY (userKeyId) REFERENCES user_keys(id) ON DELETE CASCADE;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE forum_user_keys DROP FOREIGN KEY forum_user_keys_ibfk_2;
                 ALTER TABLE forum_user_keys ADD CONSTRAINT forum_user_keys_ibfk_2 
                 FOREIGN KEY (userKeyId) REFERENCES user_keys(id);";

            Execute.Sql(sql);
        }
    }
}
