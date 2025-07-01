using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250627143443)]
    public class AddPinnedMessageSupportToForumChat : Migration
    {
        public override void Up()
        {
            string sql = @"
                ALTER TABLE `forum_chat` 
                ADD COLUMN `isPinned` BOOLEAN NOT NULL DEFAULT FALSE,
                ADD COLUMN `pinnedAt` DATETIME DEFAULT NULL,
                ADD COLUMN `pinnedBy` INT DEFAULT NULL,
                ADD CONSTRAINT `fk_forum_chat_pinned_by` FOREIGN KEY (`pinnedBy`) REFERENCES `users` (`id`) ON DELETE SET NULL;
            ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = @"
                ALTER TABLE `forum_chat` 
                DROP FOREIGN KEY `fk_forum_chat_pinned_by`,
                DROP COLUMN `pinnedBy`,
                DROP COLUMN `pinnedAt`,
                DROP COLUMN `isPinned`;
            ";

            Execute.Sql(sql);
        }
    }
}
