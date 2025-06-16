using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250616000001)]
    public class AddCategoryIdToForums : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE forums 
                 ADD COLUMN categoryId int,
                 ADD FOREIGN KEY (categoryId) REFERENCES categories(id);";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE forums 
                 DROP FOREIGN KEY forums_ibfk_1,
                 DROP COLUMN categoryId;";
            Execute.Sql(sql);
        }
    }
}
