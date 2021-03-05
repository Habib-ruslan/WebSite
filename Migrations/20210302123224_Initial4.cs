using Microsoft.EntityFrameworkCore.Migrations;

namespace _1.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageModel_PostModels_PostModelId",
                table: "ImageModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageModel",
                table: "ImageModel");

            migrationBuilder.RenameTable(
                name: "ImageModel",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_ImageModel_PostModelId",
                table: "Images",
                newName: "IX_Images_PostModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_PostModels_PostModelId",
                table: "Images",
                column: "PostModelId",
                principalTable: "PostModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_PostModels_PostModelId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "ImageModel");

            migrationBuilder.RenameIndex(
                name: "IX_Images_PostModelId",
                table: "ImageModel",
                newName: "IX_ImageModel_PostModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageModel",
                table: "ImageModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageModel_PostModels_PostModelId",
                table: "ImageModel",
                column: "PostModelId",
                principalTable: "PostModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
