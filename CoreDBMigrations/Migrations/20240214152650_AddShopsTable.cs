using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240214152650)]
    public class AddShopsTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS shops CASCADE;
                CREATE TABLE shops (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT, 
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    cityId int,
                    name varchar(255),
                    address varchar(255),
                    latitude double,
                    longitude double,
                    access_key varchar(255),
                    description varchar(255)
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS shops CASCADE;";

            Execute.Sql(sql);
        }
    }
}
