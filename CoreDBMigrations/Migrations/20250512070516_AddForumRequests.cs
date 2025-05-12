using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250512070516)]
    public class AddForumRequests: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS forum_requests;
                CREATE TABLE forum_requests (
                id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
                    forumId int, 
                    FOREIGN KEY(forumId) REFERENCES forums(id),    
                    userId int, 
                    FOREIGN KEY(userId) REFERENCES users(id),
                    statusId int,
                    FOREIGN KEY(statusId) REFERENCES forum_status(id),
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    reason varchar(255)
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS forum_requests;";

            Execute.Sql(sql);
        }
    }
}