using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20241219125739)]
    public class AddPollOptionsTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS poll_options;
               CREATE TABLE poll_options (
                    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    listingId INT,
                    title VARCHAR(255),
                    votes INT,
                    FOREIGN KEY (listingId) REFERENCES listings(id)
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS poll_options;";

            Execute.Sql(sql);
        }
    }
}
