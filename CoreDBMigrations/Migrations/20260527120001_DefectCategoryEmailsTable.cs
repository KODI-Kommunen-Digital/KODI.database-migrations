using FluentMigrator;

namespace CoreDBMigrations.Migrations
{
    [Migration(20260527120001)]
    public class DefectCategoryEmailsTable : Migration
    {
        public override void Up()
        {
            string sql =
               @"CREATE TABLE IF NOT EXISTS defect_category_emails (
                    id        INT          NOT NULL AUTO_INCREMENT,
                    category  VARCHAR(255) NOT NULL UNIQUE,
                    emails    TEXT         NOT NULL,
                    PRIMARY KEY (id)
                );

                INSERT INTO defect_category_emails (category, emails) VALUES
                    ('Bäume',                                 'gruenpflege@gera.de,Naturschutz@gera.de'),
                    ('Grün- und Parkanlagen, Spielplätze',    'gruenpflege@gera.de'),
                    ('Friedhöfe',                             'friedhof@gera.de'),
                    ('Abfall – Schrottfahrzeuge',             'oa.leitstelle@gera.de'),
                    ('Baumschutz',                            'umwelt@gera.de'),
                    ('Schutzgebiete',                         'umwelt@gera.de'),
                    ('Straßenschäden / Gehwegschäden',        'Strassenservice@Gera.de'),
                    ('Straßenbeleuchtung / Ampeln',           'Stadttechnik@Gera.de');

                ALTER TABLE defect_reports
                    ADD COLUMN category VARCHAR(255) NULL;";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql =
               @"DROP TABLE IF EXISTS defect_category_emails;

                ALTER TABLE defect_reports
                    DROP COLUMN category;";

            Execute.Sql(sql);
        }
    }
}
