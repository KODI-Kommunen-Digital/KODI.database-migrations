using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250519153100)]
    public class CreateCarParkListTableAndSeedData : Migration
    {
        public override void Up()
        {
            // Create the carparklist table
            Execute.Sql(@"
                CREATE TABLE carparklist (
                    id VARCHAR(100) NOT NULL,
                    name VARCHAR(100) DEFAULT NULL,
                    address VARCHAR(200) DEFAULT NULL,
                    `free` VARCHAR(50) DEFAULT NULL,
                    capacity VARCHAR(50) DEFAULT NULL,
                    ampel VARCHAR(50) DEFAULT NULL,
                    roof VARCHAR(50) DEFAULT NULL,
                    lon VARCHAR(200) DEFAULT NULL,
                    lat VARCHAR(200) DEFAULT NULL,
                    monday VARCHAR(100) DEFAULT NULL,
                    tuesday VARCHAR(100) DEFAULT NULL,
                    wednesday VARCHAR(100) DEFAULT NULL,
                    thursday VARCHAR(100) DEFAULT NULL,
                    friday VARCHAR(100) DEFAULT NULL,
                    saturday VARCHAR(100) DEFAULT NULL,
                    sunday VARCHAR(100) DEFAULT NULL,
                    PRIMARY KEY (id)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
            ");

            // Insert seed data
            Execute.Sql(@"
                INSERT INTO carparklist 
                (id, name, address, `free`, capacity, ampel, roof, lon, lat, monday, tuesday, wednesday, thursday, friday, saturday, sunday)
                VALUES
                ('210', 'Parkhaus Wallstr.', 'Wallstraße 30 ', '143', '160', '3', '1', '6.849502', '51.296042', '07:00–23:00 Uhr', '07:00–23:00 Uhr', '07:00–23:00 Uhr', '07:00–23:00 Uhr', '07:00–23:00 Uhr', '07:00–17:00 Uhr', NULL),
                ('211', 'Parkhaus Medienzentrum Grabenstr.', 'Grabenstr. 21 ', '57', '81', '3', '1', '6.846690', '51.298700', '07:00–23:00 Uhr', '07:00–23:00 Uhr', '07:00–23:00 Uhr', '07:00–23:00 Uhr', '07:00–23:00 Uhr', '07:00–00:00 Uhr', '08:00–21:00 Uhr'),
                ('212', 'Parkhaus Angerstr.', 'Mülheimer Str. 3 ', '61', '112', '3', '1', '6.853350', '51.298784', '07:00–23:00 Uhr', '07:00–23:00 Uhr', '07:00–23:00 Uhr', '07:00–23:00 Uhr', '07:00–23:00 Uhr', '07:00–17:00 Uhr', NULL),
                ('213', 'Parkplatz Hans-Böckler-Str.', 'Hans-Böckler-Str.7 ', '0', '48', '0', '0', '6.851634', '51.295248', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig'),
                ('367', 'Parkhaus Sparkasse, Minoritenstrasse', 'Minoritenstr. 9-11 ', '0', '65', '0', '1', '6.846590', '51.296700', '07:00–19:00 Uhr', '07:00–19:00 Uhr', '07:00–19:00 Uhr', '07:00–20:30 Uhr', '07:00–20:30', '07:00–16:30 Uhr', NULL),
                ('381', 'Parkhaus Citytreff, Düsseldorfer Straße', 'Wallstr. 43 ', '0', '158', '0', '1', '6.848315', '51.295961', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
                ('382', 'Parkhaus Ärztezentrum, Mülheimer Straße', 'Mülheimer Str. 37 ', '0', '246', '0', '1', '6.853881', '51.300784', '05:00–23:00 Uhr', '05:00–23:00 Uhr', '05:00–23:00 Uhr', '05:00–23:00 Uhr', '05:00–23:00 Uhr', '05:00–23:00 Uhr', '05:00–23:00 Uhr'),
                ('383', 'Parkhaus Stadttor, Wallstraße', 'Bechemer Straße 22 ', '0', '64', '0', '1', '6.850619', '51.296168', '07:00–21:00 Uhr', '07:00–21:00 Uhr', '07:00–21:00 Uhr', '07:00–21:00 Uhr', '07:00–21:00 Uhr', '08:00–19:00 Uhr', NULL),
                ('385', 'Parkplatz, Werdener Straße / Friedhofstraße', 'Werdener Straße 22 ', '0', '71', '0', '0', '6.849180', '51.299830', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig'),
                ('386', 'Parkplatz Stadthalle, Schützenstraße', 'Schützenstraße 1 ', '0', '154', '0', '0', '6.850700', '51.294106', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig'),
                ('387', 'Parkplatz Stadttheater, Schützenstraße', 'Schützenstraße 21A ', '0', '88', '0', '0', '6.851470', '51.292800', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig'),
                ('388', 'Parkplatz Musikschule, Poststraße', 'Poststraße 23 ', '0', '40', '0', '0', '6.854833', '51.296083', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig'),
                ('392', 'Parkplatz Kirchgasse', 'Kirchgasse 21 ', '0', '50', '0', '0', '6.851455', '51.298204', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig', 'Ganztägig'),
                ('394', 'Kurzparkplatz Düsseldorfer Platz', 'Düsseldorfer Platz 4-5 ', '0', '0', '0', '0', '6.847500', '51.295090', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
                ('4665', 'Parkhaus Rathaus', 'Minoritenstr.2 ', '28', '79', '3', '1', '6.847673', '51.297521', '07:00–23:00 Uhr', '07:00–23:00 Uhr', '07:00–23:00 Uhr', '07:00–23:00 Uhr', '07:00–23:00 Uhr', '07:00–00:00 Uhr', '08:00–21:00 Uhr');
            ");
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE IF EXISTS carparklist;");
        }
    }
}
