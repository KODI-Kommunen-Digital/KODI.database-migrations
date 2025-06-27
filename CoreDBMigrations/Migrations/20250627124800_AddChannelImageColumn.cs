using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250627124800)]
    public class AddChannelImageColumn : Migration
    {
        public override void Up()
        {
            string sql = @"
                ALTER TABLE `channels` 
                ADD COLUMN `channelImage` varchar(255) DEFAULT NULL;
            ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = @"
                ALTER TABLE `channels` 
                DROP COLUMN `channelImage`;
            ";

            Execute.Sql(sql);
        }
    }
}
