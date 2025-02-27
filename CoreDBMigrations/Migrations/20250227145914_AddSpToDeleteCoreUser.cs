using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20250227145914)]
    public class AddAddSpToDeleteCoreUser : Migration
    {
        public override void Up()
        {
            string sql =
               @"
                DROP PROCEDURE IF EXISTS sp_DeleteCoreUser;
                CREATE PROCEDURE sp_DeleteCoreUser (IN userId int) 
                BEGIN
                    DECLARE EXIT HANDLER FOR SQLEXCEPTION 
                        BEGIN
                            ROLLBACK;
                            RESIGNAL;
                        END;
                    START TRANSACTION;
                        SET SQL_SAFE_UPDATES = 0;
		                DELETE FROM user_cityuser_mapping cum WHERE cum.userId = userId;
		                DELETE FROM user_listing_mapping ulm WHERE ulm.userId = userId;
		                DELETE FROM refreshtokens rt WHERE rt.userId = userId;
		                DELETE FROM forgot_password_tokens fpt WHERE fpt.userId = userId;
		                DELETE FROM verification_tokens vt WHERE vt.userId = userId;
                        DELETE FROM user_preference_cities upc WHERE upc.userId = userId;
                        DELETE FROM user_preference_categories upcat WHERE upcat.userId = userId;
                        DELETE FROM firebase_token ft WHERE ft.userId = userId;
		                DELETE FROM favorites f WHERE f.userId = userId;

		                DELETE FROM users u WHERE u.id = userId;

                        SET SQL_SAFE_UPDATES = 1;
                    COMMIT;
                END;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
                @"DROP PROCEDURE IF EXISTS sp_DeleteCoreUser;";

            Execute.Sql(sql);
        }
    }
}
