using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MrBaan.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelsAndDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectImageModels_ProjectModels_ProjectId",
                table: "ProjectImageModels");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ProjectImageModels",
                newName: "ProjectModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectImageModels_ProjectId",
                table: "ProjectImageModels",
                newName: "IX_ProjectImageModels_ProjectModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectImageModels_ProjectModels_ProjectModelId",
                table: "ProjectImageModels",
                column: "ProjectModelId",
                principalTable: "ProjectModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectImageModels_ProjectModels_ProjectModelId",
                table: "ProjectImageModels");

            migrationBuilder.RenameColumn(
                name: "ProjectModelId",
                table: "ProjectImageModels",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectImageModels_ProjectModelId",
                table: "ProjectImageModels",
                newName: "IX_ProjectImageModels_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectImageModels_ProjectModels_ProjectId",
                table: "ProjectImageModels",
                column: "ProjectId",
                principalTable: "ProjectModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
