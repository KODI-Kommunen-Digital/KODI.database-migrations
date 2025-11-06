using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20251106053410)]
    public class AddPermissionTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                CREATE TABLE `permissions` (
                `id` INT NOT NULL AUTO_INCREMENT,
                `name` VARCHAR(255) NOT NULL,          -- e.g., createEvent, createNews
                `description` VARCHAR(255) DEFAULT NULL,
                PRIMARY KEY (`id`),
                UNIQUE KEY `UC_PermissionName` (`name`)
            );";

            Execute.Sql(sql);
        }

        public override void Down()
        {
           string sql =
               @"DROP TABLE IF EXISTS `permissions`";

            Execute.Sql(sql);
        }
    }
}
