using Microsoft.EntityFrameworkCore.Migrations;

namespace Triton_Express.Migrations
{
    public partial class branch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Parcels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_BranchId",
                table: "Parcels",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Branches_BranchId",
                table: "Parcels",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Branches_BranchId",
                table: "Parcels");

            migrationBuilder.DropIndex(
                name: "IX_Parcels_BranchId",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Parcels");
        }
    }
}
