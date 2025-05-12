using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250512070657)]
    public class AddForumComments: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS forum_comments;
                CREATE TABLE forumcomments (
                    id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    forumId int, 
                    FOREIGN KEY(forumId) REFERENCES forums(id),  
                    postId int, 
                    FOREIGN KEY(postId) REFERENCES forumposts(id),  
                    userId int, 
                    FOREIGN KEY(userId) REFERENCES users(id),
                    comment varchar(1000),
                    createdAt DATETIME,
                    parentId int,
                    FOREIGN KEY(parentId) REFERENCES forumcomments(id)
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS forum_comments;";

            Execute.Sql(sql);
        }
    }
}