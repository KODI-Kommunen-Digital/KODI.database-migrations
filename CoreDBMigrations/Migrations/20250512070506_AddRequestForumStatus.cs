using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250512070506)]
    public class AddRequestForumStatus: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS forumstatus;
                CREATE TABLE forumstatus (
                    id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    name varchar(255)
                );
                insert into forumstatus values (1,""Pending""), (2,""Accepted""), (3,""Rejected"");";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS forumstatus;";

            Execute.Sql(sql);
        }
    }
}