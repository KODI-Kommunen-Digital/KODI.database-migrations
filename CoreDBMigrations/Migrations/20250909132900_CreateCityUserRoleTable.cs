using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20250909132900)]
    public class CreateCityUserRoleTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                CREATE TABLE `city_user_roles` (
                `cityId` int NOT NULL,
                `userId` int NOT NULL,
                `isAdmin` tinyint(1) DEFAULT '0',
                KEY `FK_CityUserRoles_City` (`cityId`),
                KEY `FK_CityUserRoles_User` (`userId`),
                CONSTRAINT `FK_CityUserRoles_City` FOREIGN KEY (`cityId`) REFERENCES `cities` (`id`),
                CONSTRAINT `FK_CityUserRoles_User` FOREIGN KEY (`userId`) REFERENCES `users` (`id`)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS city_user_roles;");
        }
    }
}