using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20240214153029)]
    public class AddPaymentsTable: Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS payments CASCADE;
                CREATE TABLE payments (
	                id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    createdAt DATETIME,
                    updatedAt DATETIME,
                    deletedAt DATETIME,
                    paymentId varchar(255),
                    paymentProviderType varchar(255),
                    status int,
                    amount double,
                    FOREIGN KEY (status) REFERENCES paymentstatus(id) ON DELETE CASCADE
                );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS payments CASCADE;";

            Execute.Sql(sql);
        }
    }
}
