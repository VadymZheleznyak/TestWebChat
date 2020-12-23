using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWebChat.Infrastructure.Migrations.TestWebChat
{
    public partial class Added_Room_Primary_Key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Rooms",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rooms",
                newName: "RoomId");
        }
    }
}
