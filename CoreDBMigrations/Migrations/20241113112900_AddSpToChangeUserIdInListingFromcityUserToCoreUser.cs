using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20241113112934)]
    public class AddSpToChangeUserIdInListingFromcityUserToCoreUser : Migration
    {
        public override void Up()
        {
            string sql =
               @"
                DROP PROCEDURE IF EXISTS sp_UpdateUserIdInListingFromcityUserToCoreUsers;
                PROCEDURE `sp_UpdateUserIdInListingFromcityUserToCoreUsers`()
                BEGIN
                    DECLARE done INT DEFAULT FALSE;
                    DECLARE cityId INT;
                    DECLARE citySchemaName VARCHAR(100);

                    -- Cursor to iterate over each city and its schema name
                    DECLARE city_cursor CURSOR FOR 
                        SELECT id, CONCAT('heidi_city_', id) AS schemaName 
                        FROM heidi_core.cities;

                    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

                    OPEN city_cursor;

                    city_loop: LOOP
                        FETCH city_cursor INTO cityId, citySchemaName;
                        IF done THEN
                            LEAVE city_loop;
                        END IF;

                        IF cityId IS NULL OR citySchemaName IS NULL THEN
                            ITERATE city_loop;
                        END IF;


                        SET @alter_query = CONCAT('
                            ALTER TABLE ', citySchemaName, '.listings
                            DROP FOREIGN KEY listings_ibfk_1
                        ');

                        PREPARE alter_stmt FROM @alter_query;
                        EXECUTE alter_stmt;
                        DEALLOCATE PREPARE alter_stmt;

                        SET @update_query = CONCAT('
                            UPDATE ', citySchemaName, '.listings AS t1
                            JOIN ', citySchemaName, '.users AS mt 
                            ON t1.userId = mt.id'
                            SET t1.userId = mt.coreUserId
                        ');

                        PREPARE update_stmt FROM @update_query;
                        EXECUTE update_stmt;
                        DEALLOCATE PREPARE update_stmt;
                    END LOOP;

                    CLOSE city_cursor;
                END";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
                @"DROP PROCEDURE IF EXISTS sp_UpdateUserIdInListingFromcityUserToCoreUsers;";

            Execute.Sql(sql);
        }
    }
}
