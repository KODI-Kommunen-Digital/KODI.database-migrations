using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250512070308)]
    public class AddForumPosts: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS forum_posts;
                CREATE TABLE forumposts(
                    id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    forumId int, 
                    FOREIGN KEY(forumId) REFERENCES forums(id),    
                    title varchar(255),
                    description varchar(10000),
                    userId int, 
                    FOREIGN KEY(userId) REFERENCES users(id),
                    image varchar(255),
                    createdAt DATETIME,
                    isHidden tinyint(1)
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS forum_posts;";

            Execute.Sql(sql);
        }
    }
}