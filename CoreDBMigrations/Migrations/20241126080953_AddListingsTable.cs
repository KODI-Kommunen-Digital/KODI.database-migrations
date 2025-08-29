using FluentMigrator;
namespace CoreDBMigrations.Migrations
{
    [Migration(20241126080953)]
    public class AddListingsTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS listings;
                CREATE TABLE listings (
                    id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    userId INT,
                    title VARCHAR(255),
                    place VARCHAR(255),
                    description TEXT,
                    externalId TEXT,
                    categoryId INT,
                    subcategoryId INT,
                    address VARCHAR(255),
                    email VARCHAR(255),
                    phone VARCHAR(255),
                    website TEXT,
                    price DOUBLE,
                    discountPrice DOUBLE,
                    statusId INT,
                    sourceId INT,
                    longitude DOUBLE,
                    latitude DOUBLE,
                    villageId INT,
                    startDate DATETIME,
                    endDate DATETIME,
                    createdAt DATETIME,
                    pdf VARCHAR(255),
                    expiryDate DATETIME,
                    updatedAt DATETIME,
                    zipcode INT,
                    showExternal TINYINT(1),
                    appointmentId INT,
                    viewCount INT,
                    FOREIGN KEY (userId) REFERENCES users(id) ON DELETE CASCADE,
                    FOREIGN KEY (categoryId) REFERENCES categories(id) ON DELETE CASCADE,
                    FOREIGN KEY (subcategoryId) REFERENCES subcategory(id) ON DELETE CASCADE,
                    FOREIGN KEY (statusId) REFERENCES status(id) ON DELETE CASCADE,
                    FOREIGN KEY (sourceId) REFERENCES source(id) ON DELETE CASCADE, --
                    FOREIGN KEY (villageId) REFERENCES village(id) ON DELETE CASCADE
                );";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS listings;";

            Execute.Sql(sql);
        }
    }
}
