using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoringAPI.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrontUuid = table.Column<Guid>(nullable: false),
                    Step = table.Column<int>(nullable: false),
                    IsFinished = table.Column<bool>(nullable: false),
                    Person_Name = table.Column<string>(maxLength: 50, nullable: true),
                    Person_DateOfBirth = table.Column<DateTime>(nullable: true),
                    Person_Color = table.Column<string>(nullable: true),
                    Person_Gender = table.Column<int>(nullable: true),
                    Gluttony_EatingInDay = table.Column<int>(nullable: true),
                    Gluttony_Cookies = table.Column<bool>(nullable: true),
                    Gluttony_MostImportantType = table.Column<int>(nullable: true),
                    Gluttony_FastFood = table.Column<bool>(nullable: true),
                    Envy_EnvyToFriend = table.Column<bool>(nullable: true),
                    Envy_TryToAnnoy = table.Column<bool>(nullable: true),
                    Envy_ProudOfTheLeader = table.Column<bool>(nullable: true),
                    Greed_Hoard = table.Column<bool>(nullable: true),
                    Greed_AreYouDragon = table.Column<bool>(nullable: true),
                    Greed_Collections = table.Column<int>(nullable: true),
                    Greed_TouchebleCollection = table.Column<bool>(nullable: true),
                    Greed_CanLendMoney = table.Column<bool>(nullable: true),
                    Lust_PassionDream = table.Column<bool>(nullable: true),
                    Lust_IllegalActions = table.Column<bool>(nullable: true),
                    Lust_WasInOrgies = table.Column<bool>(nullable: true),
                    Lust_HowManyPartners = table.Column<int>(nullable: true),
                    Pride_AcceptFail = table.Column<bool>(nullable: true),
                    Pride_WhoFail = table.Column<int>(nullable: true),
                    Pride_BetterThanOther = table.Column<bool>(nullable: true),
                    Sloth_PassiveRest = table.Column<bool>(nullable: true),
                    Sloth_ReactionOnAccident = table.Column<int>(nullable: true),
                    Sloth_Servants = table.Column<int>(nullable: true),
                    Sloth_LazyDescription = table.Column<string>(nullable: true),
                    Wrath_EasyToAnger = table.Column<bool>(nullable: true),
                    Wrath_TryingToControl = table.Column<bool>(nullable: true),
                    Wrath_GodOfWar = table.Column<bool>(nullable: true),
                    Wrath_BrokenItems = table.Column<int>(nullable: true),
                    HeavenPoints = table.Column<int>(nullable: false),
                    HellPoints = table.Column<int>(nullable: false),
                    ValhallaPoints = table.Column<int>(nullable: false),
                    HelPoints = table.Column<int>(nullable: false),
                    AfterLife = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyResults", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResults_FrontUuid",
                table: "SurveyResults",
                column: "FrontUuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyResults");
        }
    }
}
