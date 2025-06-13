using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250610162000)]
    public class ModifyIsPinnedColumnToTinyInt : Migration
    {
        public override void Up()
        {
            string sql =
               @"ALTER TABLE forum_posts MODIFY COLUMN isPinned TINYINT(1) DEFAULT 0;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"ALTER TABLE forum_posts MODIFY COLUMN isPinned BOOLEAN DEFAULT FALSE;";

            Execute.Sql(sql);
        }
    }
}
