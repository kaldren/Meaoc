using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meaoc_API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(nullable: false),
                    DateSent = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    RecipientId = table.Column<int>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Users_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, "drenski666@gmail.com", "Kaloyan", "Drenski", new byte[] { 164, 179, 230, 253, 197, 173, 112, 169, 36, 219, 44, 3, 219, 173, 157, 50, 240, 52, 80, 140, 95, 90, 109, 141, 85, 239, 6, 48, 117, 183, 158, 121, 0, 144, 81, 176, 170, 224, 103, 143, 35, 104, 221, 41, 219, 234, 101, 197, 237, 51, 146, 246, 123, 182, 80, 152, 108, 110, 107, 109, 209, 92, 166, 86 }, new byte[] { 127, 250, 208, 16, 176, 94, 58, 147, 233, 89, 225, 65, 208, 248, 103, 225, 225, 128, 159, 224, 180, 242, 9, 1, 144, 232, 9, 160, 71, 65, 241, 101, 99, 154, 29, 121, 204, 84, 214, 223, 224, 200, 108, 45, 165, 60, 2, 109, 162, 29, 201, 218, 253, 56, 206, 178, 28, 118, 71, 100, 22, 234, 220, 208, 189, 64, 234, 65, 121, 17, 96, 4, 245, 4, 61, 226, 111, 203, 229, 248, 95, 192, 178, 28, 81, 174, 147, 58, 167, 126, 210, 54, 21, 171, 205, 114, 37, 42, 82, 247, 11, 236, 187, 101, 240, 72, 146, 204, 215, 211, 99, 88, 120, 137, 68, 254, 69, 143, 214, 113, 142, 135, 137, 167, 220, 78, 131, 106 }, "kdrenski" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 2, "bill@microsoft.com", "Bill", "Gates", new byte[] { 73, 178, 79, 140, 203, 225, 127, 72, 127, 52, 203, 95, 54, 56, 148, 205, 29, 249, 255, 38, 7, 127, 115, 13, 76, 85, 22, 144, 100, 221, 187, 240, 112, 15, 151, 107, 121, 227, 106, 145, 236, 173, 82, 57, 75, 138, 213, 82, 64, 40, 179, 54, 142, 245, 182, 164, 73, 142, 50, 204, 32, 5, 101, 91 }, new byte[] { 45, 61, 170, 42, 135, 176, 65, 45, 30, 10, 6, 180, 117, 5, 228, 94, 176, 156, 93, 69, 111, 24, 206, 225, 235, 255, 56, 121, 153, 153, 25, 192, 115, 138, 2, 124, 6, 178, 101, 196, 17, 71, 170, 241, 40, 181, 168, 242, 53, 181, 142, 106, 130, 15, 133, 126, 110, 15, 164, 199, 207, 252, 186, 132, 28, 203, 147, 143, 61, 200, 3, 69, 188, 112, 47, 1, 145, 156, 210, 121, 72, 73, 229, 187, 31, 1, 200, 128, 196, 39, 81, 147, 42, 94, 106, 93, 137, 142, 226, 183, 198, 237, 173, 242, 100, 41, 74, 103, 56, 165, 239, 102, 82, 41, 236, 30, 72, 0, 54, 34, 142, 86, 255, 250, 197, 218, 15, 167 }, "bill" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 3, "elon@tesla.com", "Elon", "Musk", new byte[] { 47, 147, 59, 135, 253, 226, 96, 237, 182, 4, 148, 224, 140, 208, 212, 20, 241, 182, 251, 156, 27, 28, 59, 217, 182, 247, 177, 103, 15, 84, 170, 61, 127, 195, 45, 234, 42, 168, 25, 129, 247, 19, 36, 122, 68, 173, 144, 177, 251, 23, 145, 102, 98, 15, 117, 105, 181, 226, 188, 107, 129, 13, 48, 25 }, new byte[] { 138, 28, 194, 37, 38, 179, 182, 64, 8, 128, 217, 24, 56, 190, 95, 155, 181, 2, 102, 130, 213, 13, 105, 255, 216, 147, 208, 231, 74, 79, 151, 228, 139, 47, 4, 219, 186, 61, 112, 186, 113, 81, 46, 246, 79, 46, 56, 124, 187, 138, 233, 188, 241, 56, 88, 250, 130, 42, 161, 17, 86, 155, 29, 240, 161, 192, 252, 137, 6, 159, 225, 64, 194, 126, 56, 77, 177, 143, 108, 192, 117, 221, 59, 154, 0, 106, 223, 211, 131, 6, 146, 224, 237, 15, 175, 87, 4, 34, 34, 51, 51, 4, 101, 95, 19, 22, 12, 243, 45, 71, 17, 174, 70, 244, 217, 84, 43, 211, 250, 142, 215, 173, 149, 83, 241, 114, 221, 16 }, "elon" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AuthorId", "Content", "DateSent", "IsRead", "RecipientId" },
                values: new object[] { 1, 1, "Hello there, how are you today?", new DateTime(2019, 1, 20, 14, 7, 7, 459, DateTimeKind.Local).AddTicks(5594), false, 2 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AuthorId", "Content", "DateSent", "IsRead", "RecipientId" },
                values: new object[] { 2, 3, "Wait for me. I will be ready in 10 minutes.", new DateTime(2019, 1, 20, 14, 7, 7, 461, DateTimeKind.Local).AddTicks(843), false, 1 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AuthorId", "Content", "DateSent", "IsRead", "RecipientId" },
                values: new object[] { 3, 2, "It was a pleasure seeing you!", new DateTime(2019, 1, 20, 14, 7, 7, 461, DateTimeKind.Local).AddTicks(883), false, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AuthorId",
                table: "Messages",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
