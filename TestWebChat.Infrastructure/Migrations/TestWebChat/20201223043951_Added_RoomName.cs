using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWebChat.Infrastructure.Migrations.TestWebChat
{
    public partial class Added_RoomName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "Rooms");
        }
    }
}
