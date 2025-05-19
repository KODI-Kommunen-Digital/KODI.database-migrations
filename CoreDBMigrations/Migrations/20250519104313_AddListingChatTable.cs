using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250519104313)]
    public class AddListingChatTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"DROP TABLE IF EXISTS listing_chat;
                CREATE TABLE IF NOT EXISTS listing_chat (
                id BIGINT AUTO_INCREMENT PRIMARY KEY,
                listing_id INT NOT NULL,
                sender_id INT NOT NULL,
                sender_type ENUM('user', 'admin') NOT NULL,
                message TEXT NOT NULL,
                timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                FOREIGN KEY (listing_id) REFERENCES listings(id) ON DELETE CASCADE,
                FOREIGN KEY (listsender_iding_id) REFERENCES users(id) ON DELETE CASCADE,
            );";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS listing_chat;";

            Execute.Sql(sql);
        }
    }
}
