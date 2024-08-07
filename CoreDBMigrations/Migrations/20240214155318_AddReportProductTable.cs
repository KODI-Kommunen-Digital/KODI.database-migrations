using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240214155318)]
    public class AddReportProductTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS report_product;
                CREATE TABLE report_product (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    title varchar(255),
                    description varchar(255),
                    shopId int,
                    productId int,
                    status int,
                    reportType int,
                    FOREIGN KEY (shopId) REFERENCES shops(id) ON DELETE CASCADE,
                    FOREIGN KEY (productId) REFERENCES products(id) ON DELETE CASCADE
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS report_product;";

            Execute.Sql(sql);
        }
    }
}
