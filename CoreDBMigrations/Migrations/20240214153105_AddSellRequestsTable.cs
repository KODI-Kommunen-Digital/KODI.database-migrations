using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240214153105)]
    public class AddSellRequestsTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS sellrequests CASCADE;
                CREATE TABLE sellrequests (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    userId int,
                    shopId int,
                    title varchar(255),
                    description varchar(255),
                    status int,
                    FOREIGN KEY (userId) REFERENCES users(id),
                    FOREIGN KEY (shopId) REFERENCES shops(id) ON DELETE CASCADE
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS sellrequests CASCADE;";

            Execute.Sql(sql);
        }
    }
}
