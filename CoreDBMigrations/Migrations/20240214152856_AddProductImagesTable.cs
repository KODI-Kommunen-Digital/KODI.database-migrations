using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240214152856)]
    public class AddProductImagesTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS productimages;
                CREATE TABLE productimages (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    productId int,
                    sequence int,
                    url varchar(255),
                    FOREIGN KEY (productId) REFERENCES products(id) ON DELETE CASCADE
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS productimages;";

            Execute.Sql(sql);
        }
    }
}
