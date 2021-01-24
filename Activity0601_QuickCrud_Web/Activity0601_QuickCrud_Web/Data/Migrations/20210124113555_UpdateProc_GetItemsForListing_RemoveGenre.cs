using Activity0601_QuickCrud_Web.Data.Migrations.Scripts;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Activity0601_QuickCrud_Web.Data.Migrations
{
    public partial class UpdateProc_GetItemsForListing_RemoveGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SqlResource("Activity0601_QuickCrud_Web.Data.Migrations.Scripts.Procedures.GetItemsForListing.GetItemsForListing.v0.sql");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SqlResource("Activity0601_QuickCrud_Web.Data.Migrations.Scripts.Procedures.GetItemsForListing.GetItemsForListing.v1.sql");
        }
    }
}
