using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250512070840)]
    public class AddForumCitiesTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS forum_cities;
                CREATE TABLE forum_cities(
                    forumId int, 
                    cityId int, 
                    FOREIGN KEY(forumId) REFERENCES forums(id),   
                    FOREIGN KEY(cityId) REFERENCES cities(id)                    
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS forum_cities;";

            Execute.Sql(sql);
        }
    }
}