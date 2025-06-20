using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioCV.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "Deneyims",
                columns: table => new
                {
                    DeneyimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SirketAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pozisyon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yil = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deneyims", x => x.DeneyimId);
                });

            migrationBuilder.CreateTable(
                name: "Dizis",
                columns: table => new
                {
                    DiziId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IMDbUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dizis", x => x.DiziId);
                });

            migrationBuilder.CreateTable(
                name: "Egitims",
                columns: table => new
                {
                    EgitimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OkulLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OkulAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bolum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yil = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitims", x => x.EgitimId);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yonetmen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IMDbUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.FilmId);
                });

            migrationBuilder.CreateTable(
                name: "Gonullus",
                columns: table => new
                {
                    GonulluId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KulupLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KulupAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gorev = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yil = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gonullus", x => x.GonulluId);
                });

            migrationBuilder.CreateTable(
                name: "Hakkindas",
                columns: table => new
                {
                    HakkindaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HakkindaMetni = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hakkindas", x => x.HakkindaId);
                });

            migrationBuilder.CreateTable(
                name: "Kitaps",
                columns: table => new
                {
                    KitapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yazar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaps", x => x.KitapId);
                });

            migrationBuilder.CreateTable(
                name: "Makales",
                columns: table => new
                {
                    MakaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MakaleUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makales", x => x.MakaleId);
                });

            migrationBuilder.CreateTable(
                name: "Podcasts",
                columns: table => new
                {
                    PodcastId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolumAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PodcastAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PodcastUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podcasts", x => x.PodcastId);
                });

            migrationBuilder.CreateTable(
                name: "Projes",
                columns: table => new
                {
                    ProjeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjeUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projes", x => x.ProjeId);
                });

            migrationBuilder.CreateTable(
                name: "Referanss",
                columns: table => new
                {
                    ReferansId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sirket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pozisyon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referanss", x => x.ReferansId);
                });

            migrationBuilder.CreateTable(
                name: "Sertifikas",
                columns: table => new
                {
                    SertifikaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SertifikaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sertifikas", x => x.SertifikaId);
                });

            migrationBuilder.CreateTable(
                name: "Sosyals",
                columns: table => new
                {
                    SosyalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HesapUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformLogo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sosyals", x => x.SosyalId);
                });

            migrationBuilder.CreateTable(
                name: "Tiyatros",
                columns: table => new
                {
                    TiyatroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiyatroUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiyatros", x => x.TiyatroId);
                });

            migrationBuilder.CreateTable(
                name: "YouTubes",
                columns: table => new
                {
                    YouTubeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kanal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KanalLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KanalResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YouTubes", x => x.YouTubeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Deneyims");

            migrationBuilder.DropTable(
                name: "Dizis");

            migrationBuilder.DropTable(
                name: "Egitims");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Gonullus");

            migrationBuilder.DropTable(
                name: "Hakkindas");

            migrationBuilder.DropTable(
                name: "Kitaps");

            migrationBuilder.DropTable(
                name: "Makales");

            migrationBuilder.DropTable(
                name: "Podcasts");

            migrationBuilder.DropTable(
                name: "Projes");

            migrationBuilder.DropTable(
                name: "Referanss");

            migrationBuilder.DropTable(
                name: "Sertifikas");

            migrationBuilder.DropTable(
                name: "Sosyals");

            migrationBuilder.DropTable(
                name: "Tiyatros");

            migrationBuilder.DropTable(
                name: "YouTubes");
        }
    }
}
