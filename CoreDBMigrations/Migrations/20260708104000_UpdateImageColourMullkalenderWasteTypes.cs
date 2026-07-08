using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20260708104000)]
    public class UpdateImageColourMullkalenderWasteTypes : Migration
    {
        public override void Up()
        {
            string sql =
               @"UPDATE mullkalender_waste_types SET image = 'waste/icon_tonne_restmuell_2.png',     colour = '#4B4B4B' WHERE id = 1;
                 UPDATE mullkalender_waste_types SET image = 'waste/icon_tonne_restmuell_4.png',     colour = '#4B4B4B' WHERE id = 2;
                 UPDATE mullkalender_waste_types SET image = 'waste/icon_tonne_bio_1.png',           colour = '#7E4D16' WHERE id = 3;
                 UPDATE mullkalender_waste_types SET image = 'waste/icon_tonne_bio_2.png',           colour = '#7E4D16' WHERE id = 4;
                 UPDATE mullkalender_waste_types SET image = 'waste/icon_tonne_papier_1.png',        colour = '#4D712D' WHERE id = 6;
                 UPDATE mullkalender_waste_types SET image = 'waste/icon_tonne_wertstoff_4.png',     colour = '#F2B046' WHERE id = 7;
                 UPDATE mullkalender_waste_types SET image = 'waste/icon_weihnachtsbaumabfuhr.png',  colour = '#4D712D' WHERE id = 8;
                 UPDATE mullkalender_waste_types SET image = 'waste/icon_container_restmuell_1.png', colour = '#4B4B4B' WHERE id = 9;
                 UPDATE mullkalender_waste_types SET image = 'waste/icon_container_restmuell_2.png', colour = '#4B4B4B' WHERE id = 10;
                 UPDATE mullkalender_waste_types SET image = 'waste/icon_container_restmuell_4.png', colour = '#4B4B4B' WHERE id = 11;
                 UPDATE mullkalender_waste_types SET image = 'waste/icon_container_papier_2.png',    colour = '#4D712D' WHERE id = 12;
                 UPDATE mullkalender_waste_types SET image = 'waste/icon_container_papier_4.png',    colour = '#4D712D' WHERE id = 13;
                 UPDATE mullkalender_waste_types SET image = 'waste/icon_container_bio_1.png',       colour = '#7E4D16' WHERE id = 14;
                 UPDATE mullkalender_waste_types SET image = 'waste/icon_container_bio_2.png',       colour = '#7E4D16' WHERE id = 15;
                 UPDATE mullkalender_waste_types SET image = 'waste/icon_container_wertstoff_2.png', colour = '#F2B046' WHERE id = 16;
                 UPDATE mullkalender_waste_types SET image = 'waste/icon_container_wertstoff_4.png', colour = '#F2B046' WHERE id = 17;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"UPDATE mullkalender_waste_types
                 SET image = NULL, colour = NULL
                 WHERE id IN (1, 2, 3, 4, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);";

            Execute.Sql(sql);
        }
    }
}
