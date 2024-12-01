using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fashion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sizeforcartDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SizeId",
                table: "CartDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_SizeId",
                table: "CartDetails",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_Sizes_SizeId",
                table: "CartDetails",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_Sizes_SizeId",
                table: "CartDetails");

            migrationBuilder.DropIndex(
                name: "IX_CartDetails_SizeId",
                table: "CartDetails");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "CartDetails");
        }
    }
}
