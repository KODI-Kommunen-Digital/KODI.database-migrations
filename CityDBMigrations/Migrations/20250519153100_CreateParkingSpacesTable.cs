using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250519153100)]
    public class CreateParkingSpacesTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE `parking_spaces` (
                    `id` varchar(100) NOT null PRIMARY KEY,
                    `name` varchar(100) DEFAULT NULL,
                    `address` varchar(200) DEFAULT NULL,
                    `free` int DEFAULT NULL,
                    `capacity` int DEFAULT NULL,
                    `ampel` enum('0','1','2','3') DEFAULT NULL,
                    `roof` int DEFAULT NULL,
                    `longitude` varchar(200) DEFAULT NULL,
                    `latitude` varchar(200) DEFAULT NULL
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
            ");
        }

        public override void Down()
        {
            // Corrected table name
            Execute.Sql("DROP TABLE IF EXISTS `parking_spaces`;");
        }
    }
}
