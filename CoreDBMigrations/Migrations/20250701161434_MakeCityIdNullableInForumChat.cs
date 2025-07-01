using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250701161434)]
    public class MakeCityIdNullableInForumChat : Migration
    {
        public override void Up()
        {
            string sql = @"ALTER TABLE forum_chat MODIFY cityId INT NULL;";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            // Intentionally left empty to avoid issues if cityId contains NULLs
        }
    }
} 