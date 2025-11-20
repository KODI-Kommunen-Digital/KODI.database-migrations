using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20251120032032)]
    public class AddPurposeandmunicipalColumnToChannelTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                ALTER TABLE `channels` ADD COLUMN `purpose` VARCHAR(255)  DEFAULT NULL;
                ALTER TABLE `channels` ADD COLUMN `municipalInstitution` VARCHAR(255) DEFAULT NULL;
                ";
            Execute.Sql(sql);
        }

        public override void Down()
        {
           string sql =
               @"ALTER TABLE `channels` DROP COLUMN `purpose`;
                 ALTER TABLE `channels` DROP COLUMN `municipalInstitution`;";
            Execute.Sql(sql);
        }
    }
}
