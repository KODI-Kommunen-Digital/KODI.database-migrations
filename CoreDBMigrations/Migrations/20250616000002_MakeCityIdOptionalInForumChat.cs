using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250616000002)]
    public class MakeCityIdOptionalInForumChat : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE forum_chat 
                 MODIFY COLUMN cityId int NULL;";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE forum_chat 
                 MODIFY COLUMN cityId int NOT NULL;";
            Execute.Sql(sql);
        }
    }
}
