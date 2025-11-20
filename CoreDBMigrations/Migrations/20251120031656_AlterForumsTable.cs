using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20251120031656)]
    public class AddPurposeandmunicipalColumnToForumsTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                ALTER TABLE `forums` ADD COLUMN `purpose` VARCHAR(255)  DEFAULT NULL;
                ALTER TABLE `forums` ADD COLUMN `municipalInstitution` VARCHAR(255) DEFAULT NULL;
                ";
            Execute.Sql(sql);
        }

        public override void Down()
        {
           string sql =
               @"ALTER TABLE `forums` DROP COLUMN `purpose`;
                 ALTER TABLE `forums` DROP COLUMN `municipalInstitution`;";
            Execute.Sql(sql);
        }
    }
}
