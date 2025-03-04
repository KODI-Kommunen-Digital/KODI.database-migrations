using FluentMigrator;
namespace CoreDBMigrations.Migrations
{
    [Migration(20241218074150)]
    public class AddListingImagesTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS listing_images;
                CREATE TABLE listing_images (
                    id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    imageOrder INT,
                    listingId INT,
                    logo VARCHAR(1000),
                    FOREIGN KEY(listingId) REFERENCES listings(id)
                );";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS listing_images;";

            Execute.Sql(sql);
        }
    }
}
