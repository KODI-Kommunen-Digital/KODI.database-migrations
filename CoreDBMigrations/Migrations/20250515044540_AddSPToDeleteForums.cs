using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250515044540)]
    public class AddSPToDeleteForums : Migration
    {
        public override void Up()
        {   
            /*
                Changes made
                --------------------------------------------------------------------------
                2 August 2023 -> changed postReports to RepostedPosts - Sonu
                25 Oct 2023 -> changed commentes to delete not null parents - Ajay
            */
            string sql =
               @"
                DROP PROCEDURE IF EXISTS sp_DeleteForums;
                CREATE PROCEDURE sp_DeleteForums (IN forumId int) 
                BEGIN
                    DECLARE EXIT HANDLER FOR SQLEXCEPTION 
                        BEGIN
                            ROLLBACK;
                            RESIGNAL;
                        END;
                    START TRANSACTION;
                        DELETE FROM forum_comments fc where fc.forumId = forumId and fc.parentId is not NULL;
                        DELETE FROM forum_comments fc where fc.forumId = forumId;
                        DELETE FROM forum_post_reports pr where pr.forumId = forumId;
                        DELETE FROM forum_posts fp where fp.forumId = forumId;
                        DELETE FROM forum_requests fr where fr.forumId = forumId;
                        DELETE FROM forum_members fm where fm.forumId = forumId;
                        DELETE FROM forum_cities fci where fci.forumId = forumId;
                        DELETE FROM forums fs where fs.id = forumId;
                    COMMIT;
                END;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
                @"DROP PROCEDURE IF EXISTS sp_DeleteForums;";

            Execute.Sql(sql);
        }
    }
}