using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250623100351)]
    public class UpdateForumuserKeysTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE forum_user_keys MODIFY cityId INT NULL";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE forum_user_keys MODIFY cityId INT NOT NULL";
            Execute.Sql(sql);
        }
    }
} 