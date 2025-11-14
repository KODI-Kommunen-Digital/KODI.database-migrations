using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20251106054057)]
    public class AddModeratorTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                CREATE TABLE `moderators` (
                `id` INT NOT NULL AUTO_INCREMENT,
                `cityId` INT NOT NULL,
                `userId` INT NOT NULL,
                `createdBy` INT NOT NULL,   -- the CityAdmin who created this moderator
                PRIMARY KEY (`id`),
                KEY `FK_Moderator_City` (`cityId`),
                KEY `FK_Moderator_User` (`userId`),
                CONSTRAINT `FK_Moderator_City` FOREIGN KEY (`cityId`) REFERENCES `cities` (`id`) ON DELETE CASCADE,
                CONSTRAINT `FK_Moderator_User` FOREIGN KEY (`userId`) REFERENCES `users` (`id`) ON DELETE CASCADE
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
           string sql =
               @"DROP TABLE IF EXISTS `moderators`";

            Execute.Sql(sql);
        }
    }
}
