using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20260331043020)]
    public class AddPrivateKeyColumnUserKeysTable : Migration
    {
        public override void Up()
        {
            string sql =
                @"ALTER TABLE `user_keys` ADD COLUMN `privateKey` TEXT DEFAULT NULL AFTER `publicKey`;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
                @"ALTER TABLE `user_keys` DROP COLUMN `privateKey`;";

            Execute.Sql(sql);
        }
    }
}
