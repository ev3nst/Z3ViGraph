using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ViGraph.Database.Migrations
{
    public partial class FulltextIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(
				sql: "ALTER TABLE `Users` ADD FULLTEXT full(`FullName`, `Email`);",
				suppressTransaction: true
            );

			migrationBuilder.Sql(
				sql: "ALTER TABLE `Categories` ADD FULLTEXT full(`Title`, `Description`);",
				suppressTransaction: true
            );

			migrationBuilder.Sql(
				sql: "ALTER TABLE `Videos` ADD FULLTEXT full(`Title`, `Tags`, `Description`);",
				suppressTransaction: true
            );

			migrationBuilder.Sql(
				sql: "ALTER TABLE `YTChannels` ADD FULLTEXT full(`Title`, `Keywords`, `Description`, `About`);",
				suppressTransaction: true
            );

			migrationBuilder.Sql(
				sql: "ALTER TABLE `YTCategories` ADD FULLTEXT full(`Title`);",
				suppressTransaction: true
            );

			migrationBuilder.Sql(
				sql: "ALTER TABLE `YTPlaylists` ADD FULLTEXT full(`Title`, `Description`);",
				suppressTransaction: true
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
