using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250625160019)]
    public class AddEServiceTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"CREATE TABLE eservices (
                id INT AUTO_INCREMENT PRIMARY KEY,
                parentId INT NULL,
                service VARCHAR(255) NOT NULL,
                link VARCHAR(512),
                image VARCHAR(255),
                service_type ENUM('Deep Link', 'Link') NULL,
                FOREIGN KEY (parentId) REFERENCES eservices(id) ON DELETE CASCADE
            );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS `eservices`";

            Execute.Sql(sql);
        }
    }
}
