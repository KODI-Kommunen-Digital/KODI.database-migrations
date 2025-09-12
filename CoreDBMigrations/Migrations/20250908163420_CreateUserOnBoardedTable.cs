using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20250908163420)]
    public class CreateUserOnBoardedTable : Migration
    {
        public override void Up()
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS users_onboarded (
                  `id` int NOT NULL AUTO_INCREMENT,
                  `email` varchar(255) NOT NULL,
                  `roleId` int NOT NULL,
                  `createdAt` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
                  `updatedAt` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                  `onBoarded` tinyint(1) DEFAULT '0',
                  `cities` json DEFAULT NULL,
                  PRIMARY KEY (`id`),
                  UNIQUE KEY `UC_Email` (`email`),
                  KEY `FK_RoleIdOnboard` (`roleId`),
                  CONSTRAINT `FK_RoleIdOnboard` FOREIGN KEY (`roleId`) REFERENCES `roles` (`id`)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS users_onboarded;");
        }
    }
}