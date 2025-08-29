using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20241126080951)]
    public class AddVillageTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS village;
               CREATE TABLE village (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    name VARCHAR(255) NOT NULL,
                    cityId INT,
                    FOREIGN KEY(cityId) REFERENCES cities(id) ON DELETE CASCADE
                );";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS village;";

            Execute.Sql(sql);
        }
    }
}
