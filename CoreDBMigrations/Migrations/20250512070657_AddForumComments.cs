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
                CREATE TABLE forum_comments (
                    id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    forumId int, 
                    postId int, 
                    userId int, 
                    comment varchar(1000),
                    createdAt DATETIME,
                    parentId int,
                    FOREIGN KEY(postId) REFERENCES forum_posts(id),  
                    FOREIGN KEY(userId) REFERENCES users(id),
                    FOREIGN KEY(forumId) REFERENCES forums(id),  
                    FOREIGN KEY(parentId) REFERENCES forum_comments(id)
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