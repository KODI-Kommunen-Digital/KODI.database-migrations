using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250519154730)]
    public class CreateParkingTimingsTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE `parking_timings` (
                    `day` TINYINT NOT NULL,
                    `parking_id` VARCHAR(100) NOT NULL,
                    `startTime` DATETIME DEFAULT NULL,
                    `endTime` DATETIME DEFAULT NULL,
                    PRIMARY KEY (`parking_id`, `day`),
                    CONSTRAINT `parking_timings_ibfk_1` 
                        FOREIGN KEY (`parking_id`) REFERENCES `carparklist` (`id`) ON DELETE CASCADE,
                    CONSTRAINT `parking_timings_chk_1` 
                        CHECK ((`day` BETWEEN 0 AND 6))
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
            ");
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS `parking_timings`;");
        }
    }
}
