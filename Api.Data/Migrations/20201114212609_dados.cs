using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class dados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("39ec640a-bcbf-42f1-b873-35a765d16db3"), new DateTime(2020, 11, 14, 18, 26, 9, 638, DateTimeKind.Local).AddTicks(9115), "alisson@email.com", "Administrador", new DateTime(2020, 11, 14, 18, 26, 9, 639, DateTimeKind.Local).AddTicks(8524) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("39ec640a-bcbf-42f1-b873-35a765d16db3"));
        }
    }
}
