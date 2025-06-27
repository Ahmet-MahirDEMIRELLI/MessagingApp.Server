using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessagingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicKey",
                table: "Users",
                newName: "X25519PublicKey");

            migrationBuilder.AddColumn<string>(
                name: "Ed25519PublicKey",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ed25519PublicKey",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "X25519PublicKey",
                table: "Users",
                newName: "PublicKey");
        }
    }
}
