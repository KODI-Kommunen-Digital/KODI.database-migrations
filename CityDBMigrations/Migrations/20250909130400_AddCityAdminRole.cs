using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250909130400)]
    public class AddCityAdminRole : Migration
    {
        public override void Up()
        {
            string sql = @"
                INSERT INTO roles
                (id, name)
                VALUES(4, 'City Admin');";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            Execute.Sql("DELETE FROM roles WHERE id = 4;");
        }
    }
}