using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20231025163027)]
    public class AddSPToDeleteForumMember : Migration
    {
        public override void Up()
        {
            /*
                Changes made
                --------------------------------------------------------------------------
                2 August 2023 -> changed postReports to RepostedPosts - Sonu
                10 August 2023 ->Added logic to remove reports made on the user - Ajay
                13 Sept 2023 -> Changed ReportedPosts to reportedposts - Moiz
                16 Oct 2023 -> Bugfix deleting comments gets forignkey constraint - Moiz
                08 Nov 2023 -> Updated Forum member delete to delete from forumrequest table - Amay
            */
            string sql =
               @"
                DROP PROCEDURE IF EXISTS sp_DeleteForumMember;
                CREATE PROCEDURE sp_DeleteForumMember (IN forumId int, IN userId int) 
                BEGIN
                    DECLARE EXIT HANDLER FOR SQLEXCEPTION  
                        BEGIN
                            ROLLBACK;
                            RESIGNAL;
                        END;
                    START TRANSACTION;
                        SET SQL_SAFE_UPDATES = 0;
		                DELETE FROM forumcomments fc where fc.forumId = forumId and fc.userId = userId and fc.parentId is not NULL;
                        DELETE fc1 FROM forumcomments fc1 INNER JOIN forumcomments fc2 ON fc1.parentId = fc2.id WHERE fc2.userId = userId and fc2.forumId = forumId;
                        DELETE FROM forumcomments fc where fc.forumId = forumId and fc.userId = userId;
                        DELETE FROM reportedposts rp where rp.forumId = forumId and rp.userId = userId;
                        DELETE rp FROM reportedposts rp
                        INNER JOIN forumposts fp ON rp.postId = fp.id
                        WHERE fp.userId = userId;
                        DELETE fc1 FROM forumcomments fc1 INNER JOIN forumposts fc2 ON fc1.postId = fc2.id WHERE fc2.userId = userId and fc2.forumId = forumId and fc1.parentId IS NOT NULL;
                        DELETE fc1 FROM forumcomments fc1 INNER JOIN forumposts fc2 ON fc1.postId = fc2.id WHERE fc2.userId = userId and fc2.forumId = forumId;
		                DELETE FROM forumposts fp where fp.forumId = forumId and fp.userId = userId;
		                DELETE FROM forummembers fm where fm.forumId = forumId and fm.userId = userId;
                        DELETE FROM forumrequests fr where fr.forumId = forumId and fr.userId = userId;

                        SET SQL_SAFE_UPDATES = 1;
	                COMMIT;
                END;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
                @"DROP PROCEDURE IF EXISTS sp_DeleteForumMember;";

            Execute.Sql(sql);
        }
    }
}