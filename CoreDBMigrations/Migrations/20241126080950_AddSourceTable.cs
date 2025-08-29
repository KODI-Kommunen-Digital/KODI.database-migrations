using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20241126080950)]
    public class AddSourceTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS source;
               CREATE TABLE source (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    name VARCHAR(255) NOT NULL
                );
                INSERT INTO source (name) VALUES ('User entry');
                INSERT INTO source(id, name) values (2,""Instagram"");
                INSERT INTO source(id, name) values (3,""Scrapper"");
                ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS source;";

            Execute.Sql(sql);
        }
    }
}
