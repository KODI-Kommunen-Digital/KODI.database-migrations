using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20251106054310)]
    public class AddModeratorPermissionTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                CREATE TABLE `moderator_permissions` (
                `moderatorId` INT NOT NULL,
                `permissionId` INT NOT NULL,
                PRIMARY KEY (`moderatorId`, `permissionId`),
                CONSTRAINT `FK_ModeratorPermissions_Moderator` FOREIGN KEY (`moderatorId`) REFERENCES `moderators` (`id`) ON DELETE CASCADE,
                CONSTRAINT `FK_ModeratorPermissions_Permission` FOREIGN KEY (`permissionId`) REFERENCES `permissions` (`id`) ON DELETE CASCADE
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
           string sql =
               @"DROP TABLE IF EXISTS `AddModeratorPermissionTable`";

            Execute.Sql(sql);
        }
    }
}
