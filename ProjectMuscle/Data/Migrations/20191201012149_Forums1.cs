using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMuscle.Data.Migrations
{
    public partial class Forums1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forum",
                columns: table => new
                {
                    ForumID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForumName = table.Column<string>(nullable: true),
                    ForumDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forum", x => x.ForumID);
                });

            migrationBuilder.CreateTable(
                name: "ForumBoard",
                columns: table => new
                {
                    BoardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardName = table.Column<string>(nullable: true),
                    BoardDescription = table.Column<string>(nullable: true),
                    ForumID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumBoard", x => x.BoardID);
                    table.ForeignKey(
                        name: "FK_ForumBoard_Forum_ForumID",
                        column: x => x.ForumID,
                        principalTable: "Forum",
                        principalColumn: "ForumID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ForumThread",
                columns: table => new
                {
                    ThreadID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreadTitle = table.Column<string>(nullable: true),
                    ForumBoardBoardID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumThread", x => x.ThreadID);
                    table.ForeignKey(
                        name: "FK_ForumThread_ForumBoard_ForumBoardBoardID",
                        column: x => x.ForumBoardBoardID,
                        principalTable: "ForumBoard",
                        principalColumn: "BoardID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ForumPost",
                columns: table => new
                {
                    PostID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorID = table.Column<int>(nullable: false),
                    PostDate = table.Column<DateTime>(nullable: false),
                    PostContent = table.Column<string>(nullable: true),
                    ForumThreadThreadID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumPost", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_ForumPost_ForumThread_ForumThreadThreadID",
                        column: x => x.ForumThreadThreadID,
                        principalTable: "ForumThread",
                        principalColumn: "ThreadID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumBoard_ForumID",
                table: "ForumBoard",
                column: "ForumID");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPost_ForumThreadThreadID",
                table: "ForumPost",
                column: "ForumThreadThreadID");

            migrationBuilder.CreateIndex(
                name: "IX_ForumThread_ForumBoardBoardID",
                table: "ForumThread",
                column: "ForumBoardBoardID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForumPost");

            migrationBuilder.DropTable(
                name: "ForumThread");

            migrationBuilder.DropTable(
                name: "ForumBoard");

            migrationBuilder.DropTable(
                name: "Forum");
        }
    }
}
