using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Data.Migrations
{
    public partial class Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Ratings_RatingId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_RatingId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "UserProfiles");

            migrationBuilder.CreateTable(
                name: "UsersRatings",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserProfileId = table.Column<string>(nullable: true),
                    RatingId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersRatings_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersRatings_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRatings_RatingId",
                table: "UsersRatings",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRatings_UserProfileId",
                table: "UsersRatings",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersRatings");

            migrationBuilder.AddColumn<string>(
                name: "RatingId",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_RatingId",
                table: "UserProfiles",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Ratings_RatingId",
                table: "UserProfiles",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
