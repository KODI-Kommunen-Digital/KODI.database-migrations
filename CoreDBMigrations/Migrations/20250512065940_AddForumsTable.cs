using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250512065940)]
    public class AddForums : Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS forums;
                CREATE TABLE forums (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT, 
	                forumName varchar(255) NOT NULL,
                    createdAt DATETIME,
                    description varchar(10000),
                    image varchar(255),
                    isPrivate tinyint(1)
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS forums;";

            Execute.Sql(sql);
        }
    }
}
