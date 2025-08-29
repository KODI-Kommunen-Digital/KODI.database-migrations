using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250515062317)]
    public class AddSPToDeleteForumPost : Migration
    {
        public override void Up()
        {
            string sql =
               @"
                DROP PROCEDURE IF EXISTS sp_DeleteForumPost;
                CREATE PROCEDURE sp_DeleteForumPost (IN forumId int, IN postId int) 
                BEGIN
                    DECLARE EXIT HANDLER FOR SQLEXCEPTION 
                        BEGIN
                            ROLLBACK;
                            RESIGNAL;
                        END;
                    START TRANSACTION;
                        DELETE FROM forum_comments fc where fc.forumId = forumId and fc.postId = postId and fc.parentId is not NULL;
                        DELETE FROM forum_comments fc where fc.forumId = forumId and fc.postId = postId;
                        DELETE FROM forum_post_reports rp where rp.forumId = forumId and rp.postId = postId;
		                DELETE FROM forum_posts fp where fp.forumId = forumId and fp.id = postId;
	                COMMIT;
                END;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
                @"DROP PROCEDURE IF EXISTS sp_DeleteForumPost;";

            Execute.Sql(sql);
        }
    }
}