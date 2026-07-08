using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20260708103400)]
    public class AddImageColourColumnsMullkalenderWasteTypes : Migration
    {
        public override void Up()
        {
            string sql =
               @"SET @dbname = DATABASE();

                 SET @add_image = (
                     SELECT IF(
                         COUNT(*) = 0,
                         'ALTER TABLE mullkalender_waste_types ADD COLUMN image TEXT;',
                         'SELECT 1;'
                     )
                     FROM information_schema.COLUMNS
                     WHERE TABLE_SCHEMA = @dbname
                       AND TABLE_NAME = 'mullkalender_waste_types'
                       AND COLUMN_NAME = 'image'
                 );
                 PREPARE stmt_image FROM @add_image;
                 EXECUTE stmt_image;
                 DEALLOCATE PREPARE stmt_image;

                 SET @add_colour = (
                     SELECT IF(
                         COUNT(*) = 0,
                         'ALTER TABLE mullkalender_waste_types ADD COLUMN colour TEXT;',
                         'SELECT 1;'
                     )
                     FROM information_schema.COLUMNS
                     WHERE TABLE_SCHEMA = @dbname
                       AND TABLE_NAME = 'mullkalender_waste_types'
                       AND COLUMN_NAME = 'colour'
                 );
                 PREPARE stmt_colour FROM @add_colour;
                 EXECUTE stmt_colour;
                 DEALLOCATE PREPARE stmt_colour;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"SET @dbname = DATABASE();

                 SET @drop_image = (
                     SELECT IF(
                         COUNT(*) > 0,
                         'ALTER TABLE mullkalender_waste_types DROP COLUMN image;',
                         'SELECT 1;'
                     )
                     FROM information_schema.COLUMNS
                     WHERE TABLE_SCHEMA = @dbname
                       AND TABLE_NAME = 'mullkalender_waste_types'
                       AND COLUMN_NAME = 'image'
                 );
                 PREPARE stmt_image FROM @drop_image;
                 EXECUTE stmt_image;
                 DEALLOCATE PREPARE stmt_image;

                 SET @drop_colour = (
                     SELECT IF(
                         COUNT(*) > 0,
                         'ALTER TABLE mullkalender_waste_types DROP COLUMN colour;',
                         'SELECT 1;'
                     )
                     FROM information_schema.COLUMNS
                     WHERE TABLE_SCHEMA = @dbname
                       AND TABLE_NAME = 'mullkalender_waste_types'
                       AND COLUMN_NAME = 'colour'
                 );
                 PREPARE stmt_colour FROM @drop_colour;
                 EXECUTE stmt_colour;
                 DEALLOCATE PREPARE stmt_colour;";

            Execute.Sql(sql);
        }
    }
}
