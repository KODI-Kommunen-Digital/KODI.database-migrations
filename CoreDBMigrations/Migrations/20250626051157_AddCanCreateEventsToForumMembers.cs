using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250626051157)]
    public class AddCanCreateEventsToForumMembers : Migration
    {
        public override void Up()
        {
            string sql =
                @"ALTER TABLE forum_members ADD COLUMN canCreateEvents INT NOT NULL DEFAULT 0;";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
                @"ALTER TABLE forum_members DROP COLUMN canCreateEvents;";
            Execute.Sql(sql);
        }
    }
} 