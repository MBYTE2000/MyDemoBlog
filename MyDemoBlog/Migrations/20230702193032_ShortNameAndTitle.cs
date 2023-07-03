using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDemoBlog.Migrations
{
    /// <inheritdoc />
    public partial class ShortNameAndTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("d0e76e14-395c-48d0-b7d8-446a918ed634"),
                columns: new[] { "DateOfCreate", "Text" },
                values: new object[] { new DateTime(2023, 7, 2, 19, 30, 32, 318, DateTimeKind.Utc).AddTicks(643), null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BBC859EB-01D4-4B97-941A-0E3F7C007794",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7c586172-f518-4409-8e99-fcd1a5d2c0b2", "AQAAAAIAAYagAAAAEDtqnhYYRpc5AzhE/mnOYROGiLvZaPLnlr4UCmE7DDERy7QukPIvejIfkf+BIHGAEw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("d0e76e14-395c-48d0-b7d8-446a918ed634"),
                column: "DateOfCreate",
                value: new DateTime(2023, 7, 2, 19, 1, 44, 625, DateTimeKind.Utc).AddTicks(8609));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BBC859EB-01D4-4B97-941A-0E3F7C007794",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "12558601-c185-4bf0-8a8e-52031836ed39", "AQAAAAIAAYagAAAAEOcVP9j8e7sM/4XOL7IeObdkO34yrzwuulv7B1fsnwkDmwAdnVKk+V9F15VbVURudQ==" });
        }
    }
}
