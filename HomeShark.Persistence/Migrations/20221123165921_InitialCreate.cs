using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeShark.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    EntityModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    EntityModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SchoolType = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<long>(type: "bigint", nullable: false),
                    Longitude = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    EntityModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StationType = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<long>(type: "bigint", nullable: false),
                    Longitude = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgentBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    EntityModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentBranches_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    EntityModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    AgentBranchId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    Receptions = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalSizeSqFt = table.Column<int>(type: "int", nullable: true),
                    IsAuction = table.Column<bool>(type: "bit", nullable: false),
                    IsChainFree = table.Column<bool>(type: "bit", nullable: false),
                    IsNewBuild = table.Column<bool>(type: "bit", nullable: false),
                    IsExtended = table.Column<bool>(type: "bit", nullable: false),
                    IsPromoted = table.Column<bool>(type: "bit", nullable: false),
                    HasDrivewayOrGarage = table.Column<bool>(type: "bit", nullable: true),
                    StatusType = table.Column<int>(type: "int", nullable: false),
                    AdvertType = table.Column<int>(type: "int", nullable: false),
                    TagType = table.Column<int>(type: "int", nullable: false),
                    PropertyType = table.Column<int>(type: "int", nullable: false),
                    TenureType = table.Column<int>(type: "int", nullable: false),
                    PriceType = table.Column<int>(type: "int", nullable: false),
                    EpcRatingType = table.Column<int>(type: "int", nullable: true),
                    CouncilTaxBandType = table.Column<int>(type: "int", nullable: true),
                    ConstructionType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_AgentBranches_AgentBranchId",
                        column: x => x.AgentBranchId,
                        principalTable: "AgentBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeyFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    EntityModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderRank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyFeatures_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    EntityModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediaType = table.Column<int>(type: "int", nullable: false),
                    OrderRank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertySchools",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    EntityCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    EntityModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DistanceMiles = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertySchools", x => new { x.PropertyId, x.SchoolId });
                    table.ForeignKey(
                        name: "FK_PropertySchools_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertySchools_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyStations",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    EntityCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    EntityModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DistanceMiles = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyStations", x => new { x.PropertyId, x.StationId });
                    table.ForeignKey(
                        name: "FK_PropertyStations_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyStations_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentBranches_AgentId",
                table: "AgentBranches",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_Name",
                table: "Agents",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KeyFeatures_PropertyId",
                table: "KeyFeatures",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_PropertyId",
                table: "Media",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_AgentBranchId",
                table: "Properties",
                column: "AgentBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_Area",
                table: "Properties",
                column: "Area");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_Location",
                table: "Properties",
                column: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_Postcode",
                table: "Properties",
                column: "Postcode");

            migrationBuilder.CreateIndex(
                name: "IX_PropertySchools_SchoolId",
                table: "PropertySchools",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyStations_StationId",
                table: "PropertyStations",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_Name",
                table: "Schools",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_Name",
                table: "Stations",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyFeatures");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "PropertySchools");

            migrationBuilder.DropTable(
                name: "PropertyStations");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "AgentBranches");

            migrationBuilder.DropTable(
                name: "Agents");
        }
    }
}
