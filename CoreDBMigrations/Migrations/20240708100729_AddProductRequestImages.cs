using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240708100729)]
    public class AddProductRequestImages: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS product_request_images CASCADE;
                CREATE TABLE product_request_images (
                    id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    productRequestId int,
                    sequence int,
                    url varchar(255),
                    FOREIGN KEY (productRequestId) REFERENCES product_requests(id) ON DELETE CASCADE
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS product_request_images CASCADE;";

            Execute.Sql(sql);
        }
    }
}
