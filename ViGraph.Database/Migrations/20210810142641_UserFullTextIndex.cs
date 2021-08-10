using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ViGraph.Database.Migrations
{
    public partial class UserFullTextIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                sql: "ALTER TABLE `Users` ADD FULLTEXT full(`name`, `email`)",
                suppressTransaction: true
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
