using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BCH.Infrasructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BchInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Bch_Name = table.Column<string>(type: "TEXT", nullable: false),
                    Bch_Height = table.Column<int>(type: "INTEGER", nullable: false),
                    Bch_Hash = table.Column<string>(type: "TEXT", nullable: false),
                    Bch_CallTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Bch_LatestUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Bch_PreviousHash = table.Column<string>(type: "TEXT", nullable: false),
                    Bch_PreviousUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Bch_PeerCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Bch_UnconfirmedCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Bch_HighFeePerKb = table.Column<int>(type: "INTEGER", nullable: false),
                    Bch_MediumFeePerKb = table.Column<int>(type: "INTEGER", nullable: false),
                    Bch_LowFeePerKb = table.Column<int>(type: "INTEGER", nullable: false),
                    Bch_LastForkHeight = table.Column<int>(type: "INTEGER", nullable: false),
                    Bch_LastForkHash = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BchInfos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BchInfos");
        }
    }
}
