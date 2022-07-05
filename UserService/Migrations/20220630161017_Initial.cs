using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NodeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GravatarId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HtmlUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FollowersUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FollowingUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GistsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StarredUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReposUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedEventsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blog = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hireable = table.Column<bool>(type: "bit", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicRepos = table.Column<int>(type: "int", nullable: false),
                    PublicGists = table.Column<int>(type: "int", nullable: false),
                    Followers = table.Column<int>(type: "int", nullable: false),
                    Following = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
