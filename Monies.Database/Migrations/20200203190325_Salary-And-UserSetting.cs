using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Monies.Database.Migrations
{
    public partial class SalaryAndUserSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "salaries",
                columns: table => new
                {
                    salary_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    active_from = table.Column<DateTime>(nullable: false),
                    active_to = table.Column<DateTime>(nullable: false),
                    value = table.Column<decimal>(nullable: false),
                    period_type = table.Column<int>(nullable: false),
                    value_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_salaries", x => x.salary_id);
                });

            migrationBuilder.CreateTable(
                name: "user_settings",
                columns: table => new
                {
                    user_setting_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    birth_date = table.Column<DateTime>(nullable: false),
                    preferred_period_type = table.Column<int>(nullable: false),
                    preferred_value_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_settings", x => x.user_setting_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "salaries");

            migrationBuilder.DropTable(
                name: "user_settings");
        }
    }
}
