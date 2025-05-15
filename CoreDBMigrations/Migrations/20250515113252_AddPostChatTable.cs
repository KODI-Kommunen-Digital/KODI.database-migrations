using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250515113252)]
    public class AddPostChatTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS forum_post_chat;
                CREATE TABLE forum_post_chat(
                    id INT NOT NULL AUTO_INCREMENT,
                    postId INT NOT NULL,
                    senderId INT NOT NULL,
                    message TEXT NOT NULL,
                    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
                    PRIMARY KEY (id),
                    FOREIGN KEY (postId) REFERENCES forum_posts(id) ,
                    FOREIGN KEY (senderId) REFERENCES users(id)                  
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS forum_post_chat;";

            Execute.Sql(sql);
        }
    }
}