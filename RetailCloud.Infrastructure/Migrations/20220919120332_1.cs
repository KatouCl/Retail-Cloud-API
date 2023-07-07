using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RetailCloud.Infrastracture.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateChange = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Inn = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Telephone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateChange = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OrganizationType = table.Column<int>(nullable: false),
                    TaxIndexType = table.Column<int>(nullable: false),
                    Inn = table.Column<string>(nullable: true),
                    Kpp = table.Column<string>(nullable: false),
                    FsrarId = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: false),
                    Country = table.Column<int>(nullable: true),
                    RegionCode = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateChange = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enterprises",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateChange = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OrganizationId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Inn = table.Column<string>(nullable: false),
                    Kpp = table.Column<string>(nullable: false),
                    FsrarId = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Telephone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enterprises_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateChange = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RoleId = table.Column<long>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Patronymic = table.Column<string>(nullable: false),
                    Inn = table.Column<string>(nullable: false),
                    Telephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupProduct",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateChange = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserCreatedId = table.Column<long>(nullable: false),
                    ProductType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    IsMarked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupProduct_User_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesJournal",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateChange = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    PaymentStatusType = table.Column<int>(nullable: false),
                    PaymentMethodType = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<long>(nullable: false),
                    KktSerialNumber = table.Column<string>(nullable: false),
                    PaymentToken = table.Column<string>(nullable: true),
                    PaymentId = table.Column<string>(nullable: true),
                    NumberTransaction = table.Column<string>(nullable: true),
                    CheckNumber = table.Column<string>(nullable: true),
                    Rrn = table.Column<string>(nullable: true),
                    FiscalNumberDocument = table.Column<string>(nullable: true),
                    SessionNumber = table.Column<int>(nullable: true),
                    QR_URL = table.Column<string>(nullable: true),
                    QR_Sign = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesJournal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesJournal_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateChange = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserCreatedId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_User_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateChange = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    GroupProductId = table.Column<long>(nullable: false),
                    UserCreatedId = table.Column<long>(nullable: false),
                    UnitsId = table.Column<long>(nullable: false),
                    ProducerId = table.Column<long>(nullable: false),
                    TaxIndexType = table.Column<int>(nullable: false),
                    ItemType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PrintName = table.Column<string>(nullable: false),
                    Artikul = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_GroupProduct_GroupProductId",
                        column: x => x.GroupProductId,
                        principalTable: "GroupProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Producer_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_User_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Barcode",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateChange = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    UserCreatedId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barcode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barcode_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Barcode_User_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesJournalPosition",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateChange = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    SalesJournalId = table.Column<long>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    Cis = table.Column<string>(nullable: true),
                    Price = table.Column<long>(nullable: false),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesJournalPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesJournalPosition_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesJournalPosition_SalesJournal_SalesJournalId",
                        column: x => x.SalesJournalId,
                        principalTable: "SalesJournal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barcode_ProductId",
                table: "Barcode",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Barcode_UserCreatedId",
                table: "Barcode",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_OrganizationId",
                table: "Enterprises",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupProduct_UserCreatedId",
                table: "GroupProduct",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_GroupProductId",
                table: "Product",
                column: "GroupProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProducerId",
                table: "Product",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UnitsId",
                table: "Product",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserCreatedId",
                table: "Product",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesJournal_UserId",
                table: "SalesJournal",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesJournalPosition_ProductId",
                table: "SalesJournalPosition",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesJournalPosition_SalesJournalId",
                table: "SalesJournalPosition",
                column: "SalesJournalId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_UserCreatedId",
                table: "Units",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barcode");

            migrationBuilder.DropTable(
                name: "Enterprises");

            migrationBuilder.DropTable(
                name: "SalesJournalPosition");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "SalesJournal");

            migrationBuilder.DropTable(
                name: "GroupProduct");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
