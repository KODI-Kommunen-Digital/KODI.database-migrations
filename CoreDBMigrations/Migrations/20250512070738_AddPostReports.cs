using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250512070738)]
    public class AddPostReports: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS post_reports;
                CREATE TABLE post_reports (
                    id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    forumId int, 
                    FOREIGN KEY(forumId) REFERENCES forums(id),  
                    postId int, 
                    FOREIGN KEY(postId) REFERENCES forum_posts(id),  
                    userId int, 
                    FOREIGN KEY(userId) REFERENCES users(id),
                    createdAt DATETIME
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS post_reports;";

            Execute.Sql(sql);
        }
    }
}