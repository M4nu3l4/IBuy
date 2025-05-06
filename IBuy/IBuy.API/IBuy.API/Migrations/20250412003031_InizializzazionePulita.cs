using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IBuy.API.Migrations
{
    /// <inheritdoc />
    public partial class InizializzazionePulita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBestSeller = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Hobby e tempo libero", "Tempo libero" },
                    { new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "Dispositivi elettronici", "Tecnologia" },
                    { new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Bellezza e cura personale", "Cosmetici" },
                    { new Guid("ab73a4ea-76fd-41cb-8a4d-4b0e9b610e38"), "Prodotti per animali", "Amici animali" },
                    { new Guid("adbf2d17-62c6-44a7-a6d7-d09d510674c5"), "Sport e outdoor", "Attrezzatura sportiva" },
                    { new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Casa e cucina", "Elettrodomestici" },
                    { new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"), "Moda uomo e donna", "Abbigliamento" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "IsBestSeller", "Name", "Price", "Producer", "Quantity" },
                values: new object[,]
                {
                    { new Guid("01139b0c-abe7-4775-886c-753303db2a0e"), new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Gioco di carte UNO classico per tutta la famiglia", "images/CarteUNOMattel.jpg", true, "Set di Carte UNO Mattel", 8.99m, "Mattel", 50 },
                    { new Guid("0342134e-4a4d-4a26-8d3f-9955a2aa7d82"), new Guid("adbf2d17-62c6-44a7-a6d7-d09d510674c5"), "Set di manubri regolabili da 2 a 24 kg", "images/ManubriRegolabiliBowflexSelectTech552.jpg", true, "Manubri Regolabili Bowflex SelectTech 552", 399.00m, "Bowflex", 15 },
                    { new Guid("05292ae8-07ed-46aa-9f1d-9fc3351f299d"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Crema rimpolpante con acido ialuronico puro per pelle rimpolpata e distesa", "images/LOrealRevitaliftFiller.jpg", true, "L'Oreal Revitalift Filler", 17.89m, "L'Oreal", 29 },
                    { new Guid("057beaa9-5f4c-43e3-8b5d-d5eca661439b"), new Guid("adbf2d17-62c6-44a7-a6d7-d09d510674c5"), "Panca da allenamento stabile e robusta", "images/PancaPianaPerformance.jpg", false, "Panca Piana Adidas Performance", 99.99m, "Adidas", 10 },
                    { new Guid("05c44beb-5677-4cc8-93b5-a66197c1b2de"), new Guid("adbf2d17-62c6-44a7-a6d7-d09d510674c5"), "Tappetino professionale antiscivolo per yoga", "images/TappetinoYogaMandukaPRO.jpg", true, "Tappetino Yoga Manduka PRO", 119.00m, "Manduka", 40 },
                    { new Guid("072f737f-fe24-4607-8caf-0a0ce58f3ff0"), new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "SSD PCIe 4.0 M.2 ultra veloce per gaming e editing", "images/SamsungSSD980PRO1TBNVMe.jpg", true, "Samsung SSD 980 PRO 1TB NVMe", 149.99m, "Samsung", 24 },
                    { new Guid("089b803d-c132-4c16-bb09-d30d831e6cf6"), new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "Smartwatch con display Super AMOLED, tracciamento sonno e ECG", "images/SamsungGalaxyWatch6.jpg", false, "Samsung Galaxy Watch 6", 319.99m, "Samsung", 33 },
                    { new Guid("0a6f1ec5-7db2-43f7-a48d-84d946e82cf1"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Trattamento anti-imperfezioni per pelli grasse a tendenza acneica", "images/LaRoche-PosayEffaclarDuo+.jpg", true, "La Roche-Posay Effaclar Duo+", 16.90m, "La Roche-Posay", 30 },
                    { new Guid("120aaf6e-ff2d-4d3c-bf56-cf4b47c5b4b0"), new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "Noise cancelling", "images/CuffieWireless.jpg", false, "Cuffie Wireless", 59.99m, "SoundMax", 60 },
                    { new Guid("14d62de2-fa36-46d2-8b42-3422bfe3e058"), new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"), "Giacca leggera e impermeabile con cuciture termosaldate", "images/NorthFaceGiaccaVenture2.jpg", true, "North Face Giacca Antipioggia Venture 2", 129.00m, "The North Face", 20 },
                    { new Guid("1a343040-4549-452d-a714-b6a0ef576c16"), new Guid("ab73a4ea-76fd-41cb-8a4d-4b0e9b610e38"), "Dispenser automatico smart per cani e gatti", "images/DispenserCiboPetkit.jpg", true, "Dispenser Automatico Cibo Petkit", 89.90m, "Petkit", 10 },
                    { new Guid("1ae30f94-92bc-4316-9346-58a612ae32f0"), new Guid("ab73a4ea-76fd-41cb-8a4d-4b0e9b610e38"), "Alimento completo per gatti sterilizzati", "images/Purina3kg.jpg", true, "Purina One Sterilcat 3kg", 16.99m, "Purina", 35 },
                    { new Guid("1c53e7cf-8591-406a-97e5-1a8d730d420f"), new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "Contapassi, sonno e cardio", "images/SmartwatchFitGo.png", true, "Smartwatch FitGo", 89.90m, "FitTech", 40 },
                    { new Guid("1f33cfa7-f52f-4076-8930-0f848b44cc34"), new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"), "Polo elegante in piqué con logo ricamato", "images/TommyHilfigerPoloBasic.jpg", false, "Tommy Hilfiger Polo Basic", 44.90m, "Tommy Hilfiger", 23 },
                    { new Guid("210f8b92-08ee-41cc-ae74-98c60f21849f"), new Guid("ab73a4ea-76fd-41cb-8a4d-4b0e9b610e38"), "Spazzola con setole retraibili per la toelettatura", "images/SpazzolaAnimali.jpg", true, "Spazzola Autopulente per Animali", 14.50m, "Pecute", 50 },
                    { new Guid("27429eb0-31fb-4204-8542-bc1aa8c0ac49"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Balsamo lenitivo multiuso per pelli sensibili, secche o irritate", "images/LaRoche-PosayCicaplastBaumeB5.jpg", true, "La Roche-Posay Cicaplast Baume B5", 14.50m, "La Roche-Posay", 30 },
                    { new Guid("2a7c08f3-fda4-4f3e-a750-a1344dc3dd89"), new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"), "T-shirt sportiva traspirante con tecnologia Dri-FIT", "images/NikeDri-FITAcademyT-ShirtUomo.jpg", true, "Nike Dri-FIT Academy T-Shirt Uomo", 27.99m, "Nike", 22 },
                    { new Guid("2d47f5dc-2bac-4ee7-b80b-a402ec6400c8"), new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"), "Felpa con cappuccio in cotone misto, stile casual", "images/AdidasEssentials.jpg", true, "Adidas Essentials Felpa Con Cappuccio", 54.99m, "Adidas", 41 },
                    { new Guid("2f24edd3-3568-4d52-8757-4cbdcf432614"), new Guid("adbf2d17-62c6-44a7-a6d7-d09d510674c5"), "Corda per salti rapidi regolabile in lunghezza", "images/CordaXSaltareBeMaxx.jpg", true, "Corda per Saltare Speed Rope BeMaxx", 16.90m, "BeMaxx", 50 },
                    { new Guid("33a2de52-3489-4780-9fe3-61e6eec6c12e"), new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Tavola gonfiabile per sport acquatici con montaggio facile", "images/cressiSup.jpg", false, "Tavola SUP Cressi Solid Isup", 399.99m, "Cressi", 7 },
                    { new Guid("3484e37c-4fd7-42e2-938c-1d82ad7d41ef"), new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "Display AMOLED e 128GB", "images/Smartphone_X100.jpg", true, "Smartphone X100", 399.99m, "TechBrand", 25 },
                    { new Guid("359bc919-86e3-431b-8b72-5b83018de709"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Robot multifunzione da 700W con accessori inclusi per impastare, tritare e grattugiare", "images/MoulinexEasyForceRobotdaCucina.jpg", true, "Moulinex Easy Force Robot da Cucina", 89.99m, "Moulinex", 50 },
                    { new Guid("3a44b124-e862-4080-bb84-de6a9b1c423e"), new Guid("adbf2d17-62c6-44a7-a6d7-d09d510674c5"), "Rullo foam per massaggi e rilascio miofasciale", "images/RulloMassaggianteGRID.jpg", false, "Rullo Massaggiante TriggerPoint GRID", 38.90m, "TriggerPoint", 25 },
                    { new Guid("3a8c19f4-fda5-5f4e-a861-a2455dc4dd90"), new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"), "Jeans classico taglio dritto, denim blu", "images/Levis501OriginalJeansDonna.jpg", true, "Levi's 501 Original Jeans", 89.00m, "Levi's", 35 },
                    { new Guid("493334d1-8d12-494b-8485-ef912c907dc7"), new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Gioco da tavolo di compravendita di proprietà", "images/MonopolyClassicoHasbro.jpg", true, "Monopoly Classico Hasbro", 29.90m, "Hasbro", 35 },
                    { new Guid("4cc1a3cb-fde8-465a-a44f-86fef040cba4"), new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Puzzle panoramico di Venezia, qualità premium", "images/Puzzle–Venezia.jpg", false, "Puzzle Ravensburger 1000 Pezzi – Venezia", 16.95m, "Ravensburger", 18 },
                    { new Guid("502f5516-fd2e-440b-9e7b-0076079f449b"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Crema viso idratante con acido ialuronico per pelle fresca e morbida", "images/NeutrogenaHydroBoostWaterGel.jpg", true, "Neutrogena Hydro Boost Water Gel", 11.90m, "Neutrogena", 26 },
                    { new Guid("5171273c-570d-4642-b5a3-81e0050e0331"), new Guid("adbf2d17-62c6-44a7-a6d7-d09d510674c5"), "5 fasce elastiche con maniglie e accessori", "images/SetElastici.jpg", true, "Set Elastici di Resistenza FitBeast", 29.99m, "FitBeast", 35 },
                    { new Guid("54506198-9f20-4da0-ae3c-2db10b81945c"), new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "Auricolari wireless con cancellazione attiva del rumore e audio spaziale", "images/AppleAirPodsPro.jpg", true, "Apple AirPods Pro (2ª generazione)", 279.00m, "Apple", 13 },
                    { new Guid("5cd30429-e765-4685-b327-ec48434bdc87"), new Guid("adbf2d17-62c6-44a7-a6d7-d09d510674c5"), "Kettlebell classico per cross training e forza", "images/Kettlebell12kg.jpg", true, "Kettlebell in Ghisa PROIRON 12kg", 39.90m, "PROIRON", 18 },
                    { new Guid("5fc54f21-39e0-4d3d-8475-24ad4f53cf72"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Siero quotidiano con acido ialuronico e acqua vulcanica per rinforzare la barriera cutanea", "images/VichyMineral89.jpg", false, "Vichy Mineral 89", 21.00m, "Vichy", 11 },
                    { new Guid("64462dc7-2faa-4f1c-9769-2a283deafca7"), new Guid("ab73a4ea-76fd-41cb-8a4d-4b0e9b610e38"), "Crocchette per cani adulti di taglia grande", "images/RoyalCanin15kg.jpg", true, "Royal Canin Maxi Adult 15kg", 64.99m, "Royal Canin", 20 },
                    { new Guid("68f65a13-8fbc-4153-9283-e2126bb891be"), new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"), "Jeans classici regular fit in denim di alta qualità", "images/Levis501OriginalJeans.jpg", true, "Levi's 501 Original Jeans Uomo", 89.90m, "Levi's", 28 },
                    { new Guid("6c91be01-d178-4dc7-bfc3-26dc8bedca3b"), new Guid("adbf2d17-62c6-44a7-a6d7-d09d510674c5"), "Kit completo per allenamento in sospensione", "images/TRXSuspensionTrainingKit.jpg", true, "TRX Suspension Training Kit", 139.00m, "TRX", 12 },
                    { new Guid("6cfa90ba-ba8e-4140-b4b6-0c82cc489973"), new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "Smart speaker con Alexa e sensore di temperatura integrato", "images/EchoDot(5_generazione).jpg", true, "Echo Dot (5ª generazione)", 64.99m, "Amazon", 34 },
                    { new Guid("736a5f6f-5d2e-4b5f-b83c-5b8fde368424"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Siero rassodante viso effetto lifting immediato", "images/LieracLiftIntegral.jpg", false, "Lierac Lift Integral Siero", 39.90m, "Lierac", 41 },
                    { new Guid("76b79275-5642-4c40-9cd6-9360a1f16f11"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Scopa elettrica senza fili con autonomia fino a 40 minuti", "images/HooverHFree100.jpg", false, "Hoover H-Free 100", 159.99m, "Hoover", 15 },
                    { new Guid("7b45e7fa-d812-4d20-9579-324ec3ff92cd"), new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"), "Set di slip in cotone elasticizzato con logo in vita", "images/CalvinKleinSlipUomo(3Pezzi).jpg", true, "Calvin Klein Slip Uomo (3 Pezzi)", 39.90m, "Calvin Klein", 30 },
                    { new Guid("7b84e964-50f0-4a17-b4a2-026d7629a5c4"), new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "Smartphone Android 6.6'' AMOLED 120Hz, 128GB, Fotocamera 108MP", "images/XiaomiRedmiNote13.jpg", false, "Xiaomi Redmi Note 13", 199.90m, "Xiaomi", 33 },
                    { new Guid("7c1a6983-a0f4-4971-bde8-ca1f5f4954ba"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Lavatrice 8kg, 1200 giri, tecnologia SensiCare per un bucato delicato", "images/ElectroluxPerfectCare600.jpg", true, "Electrolux PerfectCare 600", 469.00m, "Electrolux", 30 },
                    { new Guid("80f2b221-2498-44c4-8ae5-6c8a35b80ff3"), new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "Streaming in 4K HDR con telecomando e assistente vocale", "images/GoogleChromecast.jpg", false, "Google Chromecast con Google TV", 69.99m, "Google", 46 },
                    { new Guid("863b15aa-e0ab-4e4d-9349-e3cb085fb6a6"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Lavastoviglie da incasso 60 cm con 5 programmi e funzione ExtraDry", "images/BoschSerie2Lavastoviglie.jpg", false, "Bosch Serie 2 Lavastoviglie", 399.99m, "Bosch", 31 },
                    { new Guid("87f51894-f013-4dc4-bc7c-761f74b12389"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Effetto ciglia finte", "images/MascaraVolume.jpg", true, "Mascara Volume", 12.50m, "Maybelline", 30 },
                    { new Guid("8b0b2745-b584-4ec5-b293-91e692a48166"), new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Set completo con racchette, palline e rete da tavolo", "images/SetPingPongPortatileJOOLA.jpg", true, "Set Ping Pong Portatile JOOLA", 24.99m, "JOOLA", 19 },
                    { new Guid("8e68cb91-265e-4f9f-bc37-a7580e905e87"), new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"), "Felpa in cotone pesante con logo sul petto", "images/ChampionFelpa.jpg", true, "Champion Felpa Girocollo Small Logo", 39.90m, "Champion", 16 },
                    { new Guid("8e8b5685-1366-4e53-b99c-016f75bfaa09"), new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Diabolo per giocoleria con bastoncini in legno", "images/DiaboloJuggleDreamBastoncini.jpg", false, "Diabolo Juggle Dream con Bastoncini", 19.95m, "Juggle Dream", 12 },
                    { new Guid("99f109ae-3033-4a83-9aef-8c1c1ce08b80"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Aspirapolvere con sacco, 4.5L, alta potenza e filtraggio avanzato", "images/RowentaCompactPowerXXL.jpg", false, "Rowenta Compact Power XXL", 109.00m, "Rowenta", 20 },
                    { new Guid("a2f205bc-27ea-418c-ba00-5e13b2b03885"), new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "Mouse wireless ergonomico con scorrimento elettromagnetico e sensore 8K DPI", "images/LogitechMXMaster3S.jpg", false, "Logitech MX Master 3S", 119.00m, "Logitech", 25 },
                    { new Guid("a6756a0c-3815-4a93-a667-a369f6aeb0f5"), new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "Power bank ad alta capacità con doppia porta USB e ricarica rapida", "images/AnkerPowerCore20000mAh.jpg", false, "Anker PowerCore 20000 mAh", 49.99m, "Anker", 15 },
                    { new Guid("a6c6f8da-1f4d-42b5-b1ae-15dc5f1a2301"), new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Set 3-in-1 per costruire robot, drago o jet", "images/LEGOCreator3-in-1.jpg", true, "LEGO Creator 3-in-1 Super Robot", 19.99m, "LEGO", 20 },
                    { new Guid("a8efdc2c-d690-418c-8d8f-3f305edd3dba"), new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"), "T-shirt con logo stampato, in cotone sostenibile", "images/PumaT-ShirtDonna.jpg", true, "Puma Essentials Logo T-Shirt Donna", 16.99m, "Puma", 48 },
                    { new Guid("ac53b353-93ce-4cc1-9019-e4e46dc1e777"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Effetto lifting immediato", "images/Crema-Anti-Age.jpg", false, "Crema Anti-Age", 22.99m, "Vichy", 20 },
                    { new Guid("ad74ed2d-5c36-4138-9ffb-dd393587cb6b"), new Guid("ab73a4ea-76fd-41cb-8a4d-4b0e9b610e38"), "Cuccia soffice per cani e gatti, lavabile", "images/CucciaMorbidaAmazon.jpg", false, "Cuccia Morbida Amazon Basics", 24.99m, "Amazon Basics", 28 },
                    { new Guid("ae3fa6a3-7c0f-4e07-9c35-2f2823a98900"), new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"), "Maglia 'Iron Grey' – Uomo, tessuto traspirante con stile unico", "images/M+J+BIKE+JERSEY.png", true, "Jordan x Nigel Sylvester", 149.99m, "Nike", 15 },
                    { new Guid("af0997d3-646a-4f4f-b0d0-dbe76c67e0cf"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Vapore potente e continuo", "images/Ferro_da_stiro_SteamMax.jpg", false, "Ferro da stiro SteamMax", 39.90m, "Rowenta", 18 },
                    { new Guid("b5f80fd2-c270-4cd5-9ef2-1c9d4fc0b18f"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "500W con 3 velocità", "images/FrullatoreCompact.png", false, "Frullatore Compact", 45.00m, "Kenwood", 15 },
                    { new Guid("b94cb48e-104b-42c7-a218-fad725e476a2"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Siero viso riduttore di imperfezioni e regolatore di sebo", "images/TheOrdinaryNiacinamide.jpg", false, "The Ordinary Niacinamide 10% + Zinc 1%", 6.80m, "The Ordinary", 27 },
                    { new Guid("b99f74d1-bb8a-4c0d-bcdf-bfb5060de4e1"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Forno elettrico da incasso 71L, classe A, con funzione grill e display LED", "images/BekoFornoVentilato.jpg", false, "Beko Forno Ventilato BIE22300", 299.99m, "Beko", 34 },
                    { new Guid("b9e38a4d-0d97-4652-b8d1-ea306ac0627e"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Coperta riscaldante matrimoniale con controllo temperatura e spegnimento automatico", "images/ImetecScaldasonno.jpg", true, "Imetec Scaldasonno Sensitive", 79.90m, "Imetec", 30 },
                    { new Guid("bb06d6a8-a8b1-4f21-bbe6-f8dc371a687e"), new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "Lettore eBook impermeabile con luce regolabile e schermo antiriflesso da 6.8 pollici", "images/KindlePaperwhite.jpg", false, "Kindle Paperwhite 11ª gen", 159.99m, "Amazon", 16 },
                    { new Guid("bb102144-a85e-4561-a18d-bbcb1060d2e1"), new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Modellino da Costruire di Astronave da Collezione con Supporto, Idea Regalo di Compleanno per Adulti, Uomo, Donna e Fan dell'Attacco dei Cloni", "images/LEGOStarWars75404.jpg", false, "lego star wars x-wing fighter di luke skywalker 75301", 164.05m, "LEGO", 27 },
                    { new Guid("c6103378-7a02-449d-a53e-9fdf1d8d3ef9"), new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Frisbee per sport all'aperto, lunga gittata", "images/FrisbeeAerobiePro.jpg", true, "Set 3 Frisbee Aerobie Pro", 17.50m, "Aerobie", 28 },
                    { new Guid("c6364cb7-be80-4452-938c-3ace0f7e8c56"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Crema giorno anti-età con olio di lavanda bio, adatta a tutti i tipi di pelle", "images/GarnierBioCremaAnti-Age.jpg", true, "Garnier Bio Crema Anti-Age", 8.99m, "Garnier", 31 },
                    { new Guid("c6ea7f07-49ec-4970-924f-907b306370c7"), new Guid("ab73a4ea-76fd-41cb-8a4d-4b0e9b610e38"), "Gioco in gomma per cani da riempire con snack", "images/GiocoKongClassic.jpg", true, "Gioco Interattivo Kong Classic", 9.99m, "Kong", 60 },
                    { new Guid("ce7b2cbd-2b63-4381-8ef2-4b75bca3a02c"), new Guid("ab73a4ea-76fd-41cb-8a4d-4b0e9b610e38"), "Tiragraffi a torre con cuccia e piattaforme", "images/TiragraffiGatti.jpg", false, "Tiragraffi Relax per Gatti", 44.90m, "FEANDREA", 12 },
                    { new Guid("d1e09e9a-1cca-4ba8-b93d-8d49d34583ad"), new Guid("ab73a4ea-76fd-41cb-8a4d-4b0e9b610e38"), "Fontanella a fiore per gatti, stimola l’idratazione", "images/FontanellaAcquaFlower.jpg", true, "Fontanella Acqua Catit Flower", 27.50m, "Catit", 25 },
                    { new Guid("d2261678-527e-4afb-b52b-55d0fafdc2a8"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Crema giorno anti-rughe con Q10 e creatina per pelli mature", "images/NiveaQ10PowerAnti-Rughe.jpg", true, "Nivea Q10 Power Anti-Rughe", 9.90m, "Nivea", 11 },
                    { new Guid("d7f9d020-e965-4461-8894-a7b8ec7a7af5"), new Guid("ab73a4ea-76fd-41cb-8a4d-4b0e9b610e38"), "Borsa per il trasporto di animali di piccola taglia", "images/trasportinoTrixie.jpg", false, "Trasportino Morbido Trixie", 32.99m, "Trixie", 18 },
                    { new Guid("d85f8df7-4f2c-4fd8-b77c-c8374193f9ea"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Senza sacco, 2000W", "images/aspirapolvere.jpg", true, "Aspirapolvere Cyclone", 129.90m, "Hoover", 10 },
                    { new Guid("e2794eca-7808-402c-83de-97a3b2e9d930"), new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Pallone resistente ideale per il tempo libero", "images/PalloneAdidasTango.jpg", true, "Pallone da Calcio Adidas Tango", 14.99m, "Adidas", 32 },
                    { new Guid("e6c61ffa-0fd5-4df2-9a99-5fa0cc052853"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Olio dermocosmetico contro cicatrici, smagliature e pelle disidratata", "images/BioOilTrattamentoPelle.jpg", true, "Bio Oil Trattamento Pelle", 12.99m, "Bio Oil", 12 },
                    { new Guid("f171c52e-5b38-41a9-b05b-d8087b4d306f"), new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Modello da costruire del famoso X-Wing Starfighter", "images/LEGOStarWarsX-Wing.jpg", true, "LEGO Star Wars X-Wing", 54.99m, "LEGO", 10 },
                    { new Guid("f1c62e4d-bfe5-41ae-9050-e3c1e2f10dce"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Crema giorno nutriente", "images/CremaIdratante.jpg", true, "Crema Idratante", 14.99m, "L'Oreal", 50 },
                    { new Guid("f62b5f09-5a60-45f4-97f2-abded93bf460"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Friggitrice ad aria da 6.2L con tecnologia Rapid Air per cucinare con poco olio", "images/PhilipsAirfryerXLEssential.jpg", false, "Philips Airfryer XL Essential", 129.99m, "Philips", 18 },
                    { new Guid("f73b6f10-6a71-56f5-98f3-abded94bf571"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Multicooker intelligente con 100 ricette integrate", "images/MoulinexCookeo.jpg", true, "Moulinex Cookeo CE7041", 199.99m, "Moulinex", 15 },
                    { new Guid("f8e191d5-b382-4508-b4f9-70f97b7df8eb"), new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"), "Infradito estive classiche, comode e colorate", "images/HavaianasBrasilLogoInfradito.jpg", true, "Havaianas Brasil Logo Infradito", 21.99m, "Havaianas", 50 },
                    { new Guid("f9ed47a1-d949-482e-83f0-c3b80c1e6f19"), new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Gioco di abilità giapponese in legno colorato", "images/KendamaKromPop.jpg", false, "Kendama Krom Pop", 24.90m, "KROM", 15 },
                    { new Guid("fd8ca21e-ad1b-458f-a8ad-ff3366acdea9"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Macchina automatica per caffè in chicchi con pannarello e display soft touch", "images/DeLonghiMagnificaStart.jpg", true, "De'Longhi Magnifica Start", 319.99m, "De'Longhi", 21 },
                    { new Guid("ff6c85bb-07c6-4081-87ab-c3856b7035e0"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Tecnologia ionica", "images/phon.jpg", true, "Asciugacapelli ProDry", 34.50m, "Philips", 22 },
                    { new Guid("ffed2955-d6c1-4951-878f-a59ef6f96c2a"), new Guid("adbf2d17-62c6-44a7-a6d7-d09d510674c5"), "Palla da ginnastica 65cm con pompa inclusa", "images/PalladaPilatesGaiam.jpg", false, "Palla da Pilates Gaiam", 21.99m, "Gaiam", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ProductId",
                table: "Transactions",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
