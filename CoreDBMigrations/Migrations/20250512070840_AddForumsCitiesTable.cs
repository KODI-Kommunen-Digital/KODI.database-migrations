using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250512070840)]
    public class AddForumCities: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS forumusers;
                CREATE TABLE forumusers(
                    id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    forumId int, 
                    FOREIGN KEY(forumId) REFERENCES forums(id),    
                    cityId int, 
                    FOREIGN KEY(cityId) REFERENCES cities(id)                    
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS forumposts;";

            Execute.Sql(sql);
        }
    }
}