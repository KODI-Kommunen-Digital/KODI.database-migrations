using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20260708103400)]
    public class AddImageColourColumnsMullkalenderWasteTypes : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE mullkalender_waste_types ADD COLUMN image TEXT;
                 ALTER TABLE mullkalender_waste_types ADD COLUMN colour TEXT;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE mullkalender_waste_types DROP COLUMN image;
                 ALTER TABLE mullkalender_waste_types DROP COLUMN colour;";

            Execute.Sql(sql);
        }
    }
}
