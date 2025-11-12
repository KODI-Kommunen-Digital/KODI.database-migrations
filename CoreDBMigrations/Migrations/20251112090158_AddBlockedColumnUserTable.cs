using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20251112090158)]
    public class AddBlockedColumnUserTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                ALTER TABLE `users`
                ADD COLUMN `blocked` BOOLEAN NOT NULL DEFAULT FALSE;
                ";
            Execute.Sql(sql);
        }

        public override void Down()
        {
           string sql =
               @"ALTER TABLE `users` DROP COLUMN `blocked`;";
            Execute.Sql(sql);
        }
    }
}
