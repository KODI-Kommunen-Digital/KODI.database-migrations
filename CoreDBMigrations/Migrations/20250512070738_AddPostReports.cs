using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250512070738)]
    public class AddPostReportsTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS forum_post_reports;
                CREATE TABLE forum_post_reports (
                    id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    forumId int, 
                    postId int, 
                    userId int, 
                    Reason varchar(255),
                    createdAt DATETIME,
                    FOREIGN KEY(forumId) REFERENCES forums(id),  
                    FOREIGN KEY(userId) REFERENCES users(id),
                    FOREIGN KEY(postId) REFERENCES forum_posts(id)
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS forum_post_reports;";

            Execute.Sql(sql);
        }
    }
}