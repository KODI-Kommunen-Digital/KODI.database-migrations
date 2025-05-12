using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250512070612)]
    public class AddForumMembers: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS forum_members;
                CREATE TABLE forum_members (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT, 
                    forumId int, 
                    userId int, 
                    JoinedAt DATETIME,
                    isAdmin BOOLEAN,
                    FOREIGN KEY(forumId) REFERENCES forums(id),    
                    FOREIGN KEY(userId) REFERENCES users(id)
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS forum_members;";

            Execute.Sql(sql);
        }
    }
}
