using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250401072851)]
    public class AddSpToDeleteCityUser : Migration
    {
        public override void Up()
        {
            string sql =
               @"
               DROP PROCEDURE IF EXISTS sp_DeleteCityUser;
                CREATE PROCEDURE sp_DeleteCityUser (IN userId INT) 
                BEGIN
                    DECLARE EXIT HANDLER FOR SQLEXCEPTION 
                    BEGIN
                        ROLLBACK;
                        RESIGNAL;
                    END;

                    START TRANSACTION;
                    SET SQL_SAFE_UPDATES = 0;

                    -- Check if each table exists before running DELETE
                    IF EXISTS (SELECT 1 FROM information_schema.tables WHERE table_name = 'forumcomments') THEN
                        DELETE FROM forumcomments WHERE userId = userId AND parentId IS NOT NULL;
                    END IF;

                    IF EXISTS (SELECT 1 FROM information_schema.tables WHERE table_name = 'forumposts') THEN
                        DELETE FROM forumposts WHERE userId = userId;
                    END IF;

                    IF EXISTS (SELECT 1 FROM information_schema.tables WHERE table_name = 'reportedposts') THEN
                        DELETE FROM reportedposts WHERE userId = userId;
                    END IF;

                    IF EXISTS (SELECT 1 FROM information_schema.tables WHERE table_name = 'forummembers') THEN
                        DELETE FROM forummembers WHERE userId = userId;
                    END IF;

                    IF EXISTS (SELECT 1 FROM information_schema.tables WHERE table_name = 'forumrequests') THEN
                        DELETE FROM forumrequests WHERE userId = userId;
                    END IF;

                    DELETE li FROM listing_images li
                            INNER JOIN listings l ON l.id = li.listingId
                            WHERE l.userId = userId;

                    DELETE FROM listings l WHERE l.userId = userId;

                    DELETE FROM users WHERE id = userId;

                    SET SQL_SAFE_UPDATES = 1;
                    COMMIT;
                END;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
                @"DROP PROCEDURE IF EXISTS sp_DeleteCityUser;";

            Execute.Sql(sql);
        }
    }
}
