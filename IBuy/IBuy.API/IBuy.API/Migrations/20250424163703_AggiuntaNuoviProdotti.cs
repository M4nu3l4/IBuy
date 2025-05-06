using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IBuy.API.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntaNuoviProdotti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4cc1a3cb-fde8-465a-a44f-86fef040cba4"),
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Puzzle 2000 pezzi, qualità premium", "images/puzzle.jpg", "Puzzle Ravensburger 2000 Pezzi" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "IsBestSeller", "Name", "Price", "Producer", "Quantity" },
                values: new object[,]
                {
                    { new Guid("0d3799fc-7168-4f17-a35b-39eda9459eae"), new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Set 12 colori acrilici per hobby creativi.", "images/kitPittura.jpg", false, "Kit Pittura Acrilica", 17.90m, "Giotto", 12 },
                    { new Guid("1b4962eb-a1c7-430a-84b0-3c2a48f8519f"), new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "Lampadina led gestibile da smartphone.", "images/lampadina.jpg", false, "Lampadina Smart WiFi", 14.99m, "TP-Link", 60 },
                    { new Guid("25c84f27-dab1-4dc1-a5eb-77335f0e3fdf"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Detergente schiumogeno per tutti i tipi di pelle.", "images/bionike.jpg", false, "Detergente Viso Delicato", 7.99m, "Bionike", 20 },
                    { new Guid("26bf5eed-1c64-4628-8d2f-78eba724b441"), new Guid("ab73a4ea-76fd-41cb-8a4d-4b0e9b610e38"), "Snack masticabili gusto manzo per cani adulti.", "images/SnackCani.jpg", false, "Snack per Cani al Manzo", 2.90m, "Pedigree", 40 },
                    { new Guid("2e6b9b13-d9a1-4116-9c48-81ebf87e6f3e"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Protegge le labbra dal freddo.", "images/lipgloss.jpg", false, "Burro Cacao Nutriente", 3.99m, "Lycia", 30 },
                    { new Guid("309d258d-5256-4799-8efe-ae975f282d38"), new Guid("adbf2d17-62c6-44a7-a6d7-d09d510674c5"), "Fascia elastica per esercizi di tonificazione.", "images/SetElastici.jpg", false, "Elastico Fitness Circolare", 4.90m, "Decathlon", 40 },
                    { new Guid("3674aaf0-5928-47ab-9afd-6deebfc5656f"), new Guid("ab73a4ea-76fd-41cb-8a4d-4b0e9b610e38"), "Set spazzole e forbicine per la cura del pelo.", "images/SetSpazzoleForbicine.jpg", false, "Set Toelettatura Base", 10.90m, "Petkit", 15 },
                    { new Guid("36dbf436-d4ec-47ab-bea2-3b0df6d90dc2"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Maschera notte super idratante.", "images/maskcream.jpg", false, "Maschera Idratante Notte", 13.90m, "Sephora", 18 },
                    { new Guid("4971cff6-b843-4af1-a69b-714823a5155e"), new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Monopattino pieghevole per bambini 5+.", "images/monopattino.jpg", false, "Monopattino per Bambini", 29.99m, "Globber", 8 },
                    { new Guid("4e145c19-e470-40d5-bd5a-5b08ae8146c4"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Macchina manuale per caffè macinato.", "images/deLonghi.jpg", false, "Macchina Caffè Espresso", 69.00m, "De'Longhi", 17 },
                    { new Guid("59c48d4d-fad7-4d70-b5bd-79e7b41e37cb"), new Guid("adbf2d17-62c6-44a7-a6d7-d09d510674c5"), "Guanti per sollevamento pesi.", "images/GuantiBuilder.jpg", false, "Guanti Fitness Antiscivolo", 12.50m, "Domyos", 35 },
                    { new Guid("602e1072-56f6-43b8-b349-460513fc01ab"), new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "Mini speaker per ascolto musicale ovunque.", "images/cassaJbl.jpg", false, "Speaker Bluetooth Portatile", 18.99m, "JBL", 45 },
                    { new Guid("6096d5dc-a3f9-41d5-b8dc-2edbfb3a75e6"), new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"), "Shorts traspiranti per allenamento.", "images/pantaloncini.jpg", false, "Pantaloncini Sportivi", 14.99m, "Adidas", 35 },
                    { new Guid("62b958ca-6bef-482f-bc20-2e915aa4ce94"), new Guid("adbf2d17-62c6-44a7-a6d7-d09d510674c5"), "Cintura elastica regolabile con tasca.", "images/PortaCel.jpg", false, "Cintura Running Porta Cellulare", 9.99m, "Kalenji", 29 },
                    { new Guid("6a17b20e-2e8e-4b64-925c-43abfc5d24c0"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Siero illuminante anti-macchia.", "images/vitaminac.jpg", false, "Siero Viso Vitamina C", 19.50m, "Collistar", 12 },
                    { new Guid("73faa235-715f-4f09-86e9-388db8689da2"), new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"), "Sciarpa in lana calda.", "images/Sciarpa.jpg", false, "Sciarpa Lana Unisex", 19.90m, "Benetton", 15 },
                    { new Guid("7b14cdea-69e1-4c72-b2ef-ee0dd95e091f"), new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"), "Scarpe basse blu stile casual.", "images/converse.jpg", false, "Sneakers Casual Blu", 45.90m, "Converse", 19 },
                    { new Guid("7cafab9b-e7c5-4659-bfdc-b0d60ed9189c"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Microonde digitale con funzione grill.", "images/microonde.jpg", false, "Forno a Microonde 20L", 79.90m, "Samsung", 13 },
                    { new Guid("7dad40f9-dcec-436f-a854-029ee217d500"), new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Puzzle paesaggio di Venezia.", "images/Puzzle–Venezia.jpg", false, "Puzzle 2000 Pezzi", 15.99m, "Clementoni", 10 },
                    { new Guid("7fa7ebfd-e136-46d8-889a-2b41cab07e19"), new Guid("ab73a4ea-76fd-41cb-8a4d-4b0e9b610e38"), "Tiragraffi compatto per gatti cuccioli.", "images/Tiragraffi.jpg", false, "Tiragraffi Mini", 12.99m, "Trixie", 13 },
                    { new Guid("8162ea1f-760c-40eb-9acd-8699ae5154a9"), new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "Mouse wireless per lavoro e gaming.", "images/mousetrust.jpg", false, "Mouse Wireless Ergonomico", 29.90m, "Trust", 25 },
                    { new Guid("a080148f-a46f-4204-b9ba-57c011a6faf6"), new Guid("ab73a4ea-76fd-41cb-8a4d-4b0e9b610e38"), "Ciotola per cibo e acqua, antiscivolo.", "images/CiotolaXcibo.jpg", false, "Ciotola Doppia in Acciaio", 7.90m, "Ferplast", 20 },
                    { new Guid("a3e980f4-f4d1-4245-8cd1-2bf17e509ee6"), new Guid("adbf2d17-62c6-44a7-a6d7-d09d510674c5"), "Pallone basket per esterni.", "images/PalloneBasket.jpg", false, "Palla Basket Outdoor", 21.90m, "Molten", 18 },
                    { new Guid("b045a87c-4b52-49d2-b5b1-81a53c6dae4b"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Aspirabriciole portatile senza filo.", "images/aspirabriciole.jpg", false, "Aspirabriciole Ricaricabile", 35.00m, "Rowenta", 28 },
                    { new Guid("b2a7ae52-915f-4563-9d4f-accf256968f0"), new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"), "Struccante bifasico per occhi sensibili.", "images/garnierStruc.jpg", false, "Struccante Occhi", 5.99m, "Garnier", 15 },
                    { new Guid("c3ed6e3c-f498-4d8e-aad0-48731b9a9fbb"), new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"), "Maglietta cotone uomo/donna.", "images/fruitoftheloom.jpg", false, "T-Shirt Basic Bianca", 9.99m, "Fruit of the Loom", 44 },
                    { new Guid("c62e92cf-bbcf-45e4-b005-5424ddcc6518"), new Guid("adbf2d17-62c6-44a7-a6d7-d09d510674c5"), "Fascia per polso assorbente per lo sport.", "images/polsinonike.jpg", false, "Fascia Polso Traspirante", 6.99m, "Nike", 16 },
                    { new Guid("ceef3dd1-7296-4b63-835a-7f7293da75a1"), new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "Webcam USB con microfono integrato.", "images/icam.jpg", false, "Webcam HD 1080p", 49.99m, "Logitech", 40 },
                    { new Guid("d72e67a8-3ad0-42d6-a509-a7d5fd1176e7"), new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"), "Cappellino regolabile, vari colori.", "images/cappellinoNike.jpg", false, "Cappellino con Visiera", 8.50m, "Nike", 25 },
                    { new Guid("db33e815-7ecd-44e9-93a8-fcda641c9455"), new Guid("ab73a4ea-76fd-41cb-8a4d-4b0e9b610e38"), "Guinzaglio per cani con estensione 5 metri.", "images/Guinzaglio.jpg", false, "Guinzaglio Retrattile 5m", 14.50m, "Flexi", 21 },
                    { new Guid("ec5941df-48f2-45f5-800b-8dda367e224b"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Ventilatore silenzioso regolabile in altezza.", "images/ventilatore.jpg", false, "Ventilatore a Piantana", 36.90m, "Ardes", 22 },
                    { new Guid("ed95dc2e-8168-44ec-ae9b-c6ad3dfcb1b2"), new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Carte da gioco classiche italiane.", "images/CarteGioco.jpg", false, "Gioco di Carte Scopa", 4.99m, "Dal Negro", 26 },
                    { new Guid("f3f25433-cb03-493c-a773-25aef3a80bd0"), new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"), "Set 2 racchette, 3 palline e rete.", "images/pingpong.jpg", false, "Set Tennis da Tavolo", 22.50m, "JOOLA", 18 },
                    { new Guid("f4b15084-8dbb-47b6-8614-a83f390aa9b6"), new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"), "Tostapane compatto con espulsione automatica.", "images/tostapane.jpg", false, "Tostapane 2 Fette", 24.90m, "Imetec", 20 },
                    { new Guid("fd431bda-ed44-4dba-bd2d-dc2ac79326b8"), new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"), "Batteria portatile ricarica rapida.", "images/powerbank2.jpg", false, "Power Bank 10000mAh", 21.50m, "Anker", 32 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0d3799fc-7168-4f17-a35b-39eda9459eae"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1b4962eb-a1c7-430a-84b0-3c2a48f8519f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("25c84f27-dab1-4dc1-a5eb-77335f0e3fdf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("26bf5eed-1c64-4628-8d2f-78eba724b441"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2e6b9b13-d9a1-4116-9c48-81ebf87e6f3e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("309d258d-5256-4799-8efe-ae975f282d38"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3674aaf0-5928-47ab-9afd-6deebfc5656f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36dbf436-d4ec-47ab-bea2-3b0df6d90dc2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4971cff6-b843-4af1-a69b-714823a5155e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4e145c19-e470-40d5-bd5a-5b08ae8146c4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59c48d4d-fad7-4d70-b5bd-79e7b41e37cb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("602e1072-56f6-43b8-b349-460513fc01ab"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6096d5dc-a3f9-41d5-b8dc-2edbfb3a75e6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("62b958ca-6bef-482f-bc20-2e915aa4ce94"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6a17b20e-2e8e-4b64-925c-43abfc5d24c0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("73faa235-715f-4f09-86e9-388db8689da2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7b14cdea-69e1-4c72-b2ef-ee0dd95e091f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7cafab9b-e7c5-4659-bfdc-b0d60ed9189c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7dad40f9-dcec-436f-a854-029ee217d500"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7fa7ebfd-e136-46d8-889a-2b41cab07e19"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8162ea1f-760c-40eb-9acd-8699ae5154a9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a080148f-a46f-4204-b9ba-57c011a6faf6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a3e980f4-f4d1-4245-8cd1-2bf17e509ee6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b045a87c-4b52-49d2-b5b1-81a53c6dae4b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b2a7ae52-915f-4563-9d4f-accf256968f0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c3ed6e3c-f498-4d8e-aad0-48731b9a9fbb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c62e92cf-bbcf-45e4-b005-5424ddcc6518"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ceef3dd1-7296-4b63-835a-7f7293da75a1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d72e67a8-3ad0-42d6-a509-a7d5fd1176e7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("db33e815-7ecd-44e9-93a8-fcda641c9455"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ec5941df-48f2-45f5-800b-8dda367e224b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ed95dc2e-8168-44ec-ae9b-c6ad3dfcb1b2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f3f25433-cb03-493c-a773-25aef3a80bd0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f4b15084-8dbb-47b6-8614-a83f390aa9b6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fd431bda-ed44-4dba-bd2d-dc2ac79326b8"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4cc1a3cb-fde8-465a-a44f-86fef040cba4"),
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Puzzle panoramico di Venezia, qualità premium", "images/Puzzle–Venezia.jpg", "Puzzle Ravensburger 1000 Pezzi – Venezia" });
        }
    }
}
