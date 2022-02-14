using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KitapEvi_DataAccess.Migrations
{
    public partial class ekle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Kategori",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Kategori", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Tur",
                columns: table => new
                {
                    TurID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Tur", x => x.TurID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Yayinevi",
                columns: table => new
                {
                    YayinEviID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YayinEviAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokasyon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Yayinevi", x => x.YayinEviID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Yazar",
                columns: table => new
                {
                    YazarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YazarAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YazarSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YazarLokasyon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YazarDogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Yazar", x => x.YazarID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Kitap",
                columns: table => new
                {
                    KitapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: false),
                    YayinEviID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Kitap", x => x.KitapID);
                    table.ForeignKey(
                        name: "FK_tb_Kitap_tb_Kategori_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "tb_Kategori",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_Kitap_tb_Yayinevi_YayinEviID",
                        column: x => x.YayinEviID,
                        principalTable: "tb_Yayinevi",
                        principalColumn: "YayinEviID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KitapYazarlar",
                columns: table => new
                {
                    KitapID = table.Column<int>(type: "int", nullable: false),
                    YazarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapYazarlar", x => new { x.YazarID, x.KitapID });
                    table.ForeignKey(
                        name: "FK_KitapYazarlar_tb_Kitap_KitapID",
                        column: x => x.KitapID,
                        principalTable: "tb_Kitap",
                        principalColumn: "KitapID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitapYazarlar_tb_Yazar_YazarID",
                        column: x => x.YazarID,
                        principalTable: "tb_Yazar",
                        principalColumn: "YazarID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_KitapDetay",
                columns: table => new
                {
                    KitapDetayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolumSayisi = table.Column<int>(type: "int", nullable: false),
                    KitapSayfasi = table.Column<int>(type: "int", nullable: false),
                    Agirlik = table.Column<int>(type: "int", nullable: false),
                    KitapID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_KitapDetay", x => x.KitapDetayID);
                    table.ForeignKey(
                        name: "FK_tb_KitapDetay_tb_Kitap_KitapID",
                        column: x => x.KitapID,
                        principalTable: "tb_Kitap",
                        principalColumn: "KitapID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KitapYazarlar_KitapID",
                table: "KitapYazarlar",
                column: "KitapID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Kitap_KategoriID",
                table: "tb_Kitap",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Kitap_YayinEviID",
                table: "tb_Kitap",
                column: "YayinEviID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_KitapDetay_KitapID",
                table: "tb_KitapDetay",
                column: "KitapID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KitapYazarlar");

            migrationBuilder.DropTable(
                name: "tb_KitapDetay");

            migrationBuilder.DropTable(
                name: "tb_Tur");

            migrationBuilder.DropTable(
                name: "tb_Yazar");

            migrationBuilder.DropTable(
                name: "tb_Kitap");

            migrationBuilder.DropTable(
                name: "tb_Kategori");

            migrationBuilder.DropTable(
                name: "tb_Yayinevi");
        }
    }
}
