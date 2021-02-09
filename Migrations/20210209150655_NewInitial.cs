using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1.Migrations
{
    public partial class NewInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "PostModels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "PostModels",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
