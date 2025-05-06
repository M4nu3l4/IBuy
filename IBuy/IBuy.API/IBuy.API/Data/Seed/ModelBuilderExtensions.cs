using Microsoft.EntityFrameworkCore;
using IBuy.API.Models;


namespace IBuy.API.Data.Seed
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            var cat1 = new Guid("9fdfcfb3-54f0-4707-bf4b-3cf8e87efaa9"); // Cosmetici
            var cat2 = new Guid("2ed3f445-d087-4f76-a3e7-9c278dc160c1"); // Tecnologia
            var cat3 = new Guid("e4c3b1ee-419a-41e4-a3c2-c173509a81de"); // Elettrodomestici
            var cat4 = new Guid("f83c2b7e-1d2e-4c1f-a51f-8b745f4e5b9b"); // Abbigliamento
            var cat5 = new Guid("21f3cb15-5054-4a3a-8752-f26262ff0e88"); // Tempo libero
            var cat6 = new Guid("adbf2d17-62c6-44a7-a6d7-d09d510674c5"); // Attrezzatura sportiva
            var cat7 = new Guid("ab73a4ea-76fd-41cb-8a4d-4b0e9b610e38"); // amici animali

            modelBuilder.Entity<Category>().HasData(
         new Category { Id = cat1, Name = "Cosmetici", Description = "Bellezza e cura personale" },
         new Category { Id = cat2, Name = "Tecnologia", Description = "Dispositivi elettronici" },
         new Category { Id = cat3, Name = "Elettrodomestici", Description = "Casa e cucina" },
         new Category { Id = cat4, Name = "Abbigliamento", Description = "Moda uomo e donna" },
         new Category { Id = cat5, Name = "Tempo libero", Description = "Hobby e tempo libero" },
         new Category { Id = cat6, Name = "Attrezzatura sportiva", Description = "Sport e outdoor" },
         new Category { Id = cat7, Name = "Amici animali", Description = "Prodotti per animali" }
     );



            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = new Guid("f1c62e4d-bfe5-41ae-9050-e3c1e2f10dce"),
                    Name = "Crema Idratante",
                    CategoryId = cat1,
                    Quantity = 60,
                    Price = 14.99M,
                    Producer = "L'Oreal",
                    Description = "Crema giorno nutriente",
                    Image = "images/CremaIdratante.jpg",
                    IsBestSeller = true
                },
                new Product
                {
                    Id = new Guid("87f51894-f013-4dc4-bc7c-761f74b12389"),
                    Name = "Mascara Volume",
                    CategoryId = cat1,
                    Quantity = 40,
                    Price = 12.50M,
                    Producer = "Maybelline",
                    Description = "Effetto ciglia finte",
                    Image = "images/MascaraVolume.jpg",
                    IsBestSeller = true
                },
                new Product
                {
                    Id = new Guid("3484e37c-4fd7-42e2-938c-1d82ad7d41ef"),
                    Name = "Smartphone X100",
                    CategoryId = cat2,
                    Quantity = 40,
                    Price = 399.99M,
                    Producer = "TechBrand",
                    Description = "Display AMOLED e 128GB",
                    Image = "images/Smartphone_X100.jpg",
                    IsBestSeller = true
                },
                new Product
                {
                    Id = new Guid("120aaf6e-ff2d-4d3c-bf56-cf4b47c5b4b0"),
                    Name = "Cuffie Wireless",
                    CategoryId = cat2,
                    Quantity = 60,
                    Price = 59.99M,
                    Producer = "SoundMax",
                    Description = "Noise cancelling",
                    Image = "images/CuffieWireless.jpg",
                    IsBestSeller = false
                },
                new Product
                {
                    Id = new Guid("b5f80fd2-c270-4cd5-9ef2-1c9d4fc0b18f"),
                    Name = "Frullatore Compact",
                    CategoryId = cat3,
                    Quantity = 15,
                    Price = 45.00M,
                    Producer = "Kenwood",
                    Description = "500W con 3 velocità",
                    Image = "images/FrullatoreCompact.png",
                    IsBestSeller = false
                },
                new Product
                {
                    Id = new Guid("d85f8df7-4f2c-4fd8-b77c-c8374193f9ea"),
                    Name = "Aspirapolvere Cyclone",
                    CategoryId = cat3,
                    Quantity = 10,
                    Price = 129.90M,
                    Producer = "Hoover",
                    Description = "Senza sacco, 2000W",
                    Image = "images/aspirapolvere.jpg",
                    IsBestSeller = true
                },
                new Product
                {
                    Id = new Guid("ac53b353-93ce-4cc1-9019-e4e46dc1e777"),
                    Name = "Crema Anti-Age",
                    CategoryId = cat1,
                    Quantity = 20,
                    Price = 22.99M,
                    Producer = "Vichy",
                    Description = "Effetto lifting immediato",
                    Image = "images/Crema-Anti-Age.jpg",
                    IsBestSeller = false
                },
                new Product
                {
                    Id = new Guid("1c53e7cf-8591-406a-97e5-1a8d730d420f"),
                    Name = "Smartwatch FitGo",
                    CategoryId = cat2,
                    Quantity = 40,
                    Price = 89.90M,
                    Producer = "FitTech",
                    Description = "Contapassi, sonno e cardio",
                    Image = "images/SmartwatchFitGo.png",
                    IsBestSeller = true
                },
                new Product
                {
                    Id = new Guid("af0997d3-646a-4f4f-b0d0-dbe76c67e0cf"),
                    Name = "Ferro da stiro SteamMax",
                    CategoryId = cat3,
                    Quantity = 18,
                    Price = 39.90M,
                    Producer = "Rowenta",
                    Description = "Vapore potente e continuo",
                    Image = "images/Ferro_da_stiro_SteamMax.jpg",
                    IsBestSeller = false
                },
                new Product
                {
                    Id = new Guid("ff6c85bb-07c6-4081-87ab-c3856b7035e0"),
                    Name = "Asciugacapelli ProDry",
                    CategoryId = cat3,
                    Quantity = 22,
                    Price = 34.50M,
                    Producer = "Philips",
                    Description = "Tecnologia ionica",
                    Image = "images/phon.jpg",
                    IsBestSeller = true
                },
                new Product
                {
                    Id = new Guid("ae3fa6a3-7c0f-4e07-9c35-2f2823a98900"),
                    Name = "Jordan x Nigel Sylvester",
                    CategoryId = cat4,
                    Quantity = 15,
                    Price = 149.99M,
                    Producer = "Nike",
                    Description = "Maglia 'Iron Grey' – Uomo, tessuto traspirante con stile unico",
                    Image = "images/M+J+BIKE+JERSEY.png",
                    IsBestSeller = true
                },
                new Product
                {
                    Id = new Guid("33a2de52-3489-4780-9fe3-61e6eec6c12e"),
                    Name = "Tavola SUP Cressi Solid Isup",
                    CategoryId = cat5,
                    Quantity = 7,
                    Price = 399.99M,
                    Producer = "Cressi",
                    Description = "Tavola gonfiabile per sport acquatici con montaggio facile",
                    Image = "images/cressiSup.jpg",
                    IsBestSeller = false
                },

           

            //cosmetici

            new Product
            {
                Id = new Guid("0a6f1ec5-7db2-43f7-a48d-84d946e82cf1"),
                Name = "La Roche-Posay Effaclar Duo+",
                CategoryId = cat1,
                Quantity = 30,
                Price = 16.90M,
                Producer = "La Roche-Posay",
                Description = "Trattamento anti-imperfezioni per pelli grasse a tendenza acneica",
                Image = "images/LaRoche-PosayEffaclarDuo+.jpg",
                IsBestSeller = true
            },

new Product
{
    Id = new Guid("27429eb0-31fb-4204-8542-bc1aa8c0ac49"),
    Name = "La Roche-Posay Cicaplast Baume B5",
    CategoryId = cat1,
    Quantity = 30,
    Price = 14.50M,
    Producer = "La Roche-Posay",
    Description = "Balsamo lenitivo multiuso per pelli sensibili, secche o irritate",
    Image = "images/LaRoche-PosayCicaplastBaumeB5.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("502f5516-fd2e-440b-9e7b-0076079f449b"),
    Name = "Neutrogena Hydro Boost Water Gel",
    CategoryId = cat1,
    Quantity = 26,
    Price = 11.90M,
    Producer = "Neutrogena",
    Description = "Crema viso idratante con acido ialuronico per pelle fresca e morbida",
    Image = "images/NeutrogenaHydroBoostWaterGel.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("c6364cb7-be80-4452-938c-3ace0f7e8c56"),
    Name = "Garnier Bio Crema Anti-Age",
    CategoryId = cat1,
    Quantity = 31,
    Price = 8.99M,
    Producer = "Garnier",
    Description = "Crema giorno anti-età con olio di lavanda bio, adatta a tutti i tipi di pelle",
    Image = "images/GarnierBioCremaAnti-Age.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("d2261678-527e-4afb-b52b-55d0fafdc2a8"),
    Name = "Nivea Q10 Power Anti-Rughe",
    CategoryId = cat1,
    Quantity = 11,
    Price = 9.90M,
    Producer = "Nivea",
    Description = "Crema giorno anti-rughe con Q10 e creatina per pelli mature",
    Image = "images/NiveaQ10PowerAnti-Rughe.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("b94cb48e-104b-42c7-a218-fad725e476a2"),
    Name = "The Ordinary Niacinamide 10% + Zinc 1%",
    CategoryId = cat1,
    Quantity = 27,
    Price = 6.80M,
    Producer = "The Ordinary",
    Description = "Siero viso riduttore di imperfezioni e regolatore di sebo",
    Image = "images/TheOrdinaryNiacinamide.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("736a5f6f-5d2e-4b5f-b83c-5b8fde368424"),
    Name = "Lierac Lift Integral Siero",
    CategoryId = cat1,
    Quantity = 41,
    Price = 39.90M,
    Producer = "Lierac",
    Description = "Siero rassodante viso effetto lifting immediato",
    Image = "images/LieracLiftIntegral.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("5fc54f21-39e0-4d3d-8475-24ad4f53cf72"),
    Name = "Vichy Mineral 89",
    CategoryId = cat1,
    Quantity = 11,
    Price = 21.00M,
    Producer = "Vichy",
    Description = "Siero quotidiano con acido ialuronico e acqua vulcanica per rinforzare la barriera cutanea",
    Image = "images/VichyMineral89.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("e6c61ffa-0fd5-4df2-9a99-5fa0cc052853"),
    Name = "Bio Oil Trattamento Pelle",
    CategoryId = cat1,
    Quantity = 12,
    Price = 12.99M,
    Producer = "Bio Oil",
    Description = "Olio dermocosmetico contro cicatrici, smagliature e pelle disidratata",
    Image = "images/BioOilTrattamentoPelle.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("05292ae8-07ed-46aa-9f1d-9fc3351f299d"),
    Name = "L'Oreal Revitalift Filler",
    CategoryId = cat1,
    Quantity = 29,
    Price = 17.89M,
    Producer = "L'Oreal",
    Description = "Crema rimpolpante con acido ialuronico puro per pelle rimpolpata e distesa",
    Image = "images/LOrealRevitaliftFiller.jpg",
    IsBestSeller = true
},
//Tecnologia

new Product
{
    Id = new Guid("54506198-9f20-4da0-ae3c-2db10b81945c"),
    Name = "Apple AirPods Pro (2ª generazione)",
    CategoryId = cat2,
    Quantity = 13,
    Price = 279.00M,
    Producer = "Apple",
    Description = "Auricolari wireless con cancellazione attiva del rumore e audio spaziale",
    Image = "images/AppleAirPodsPro.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("089b803d-c132-4c16-bb09-d30d831e6cf6"),
    Name = "Samsung Galaxy Watch 6",
    CategoryId = cat2,
    Quantity = 33,
    Price = 319.99M,
    Producer = "Samsung",
    Description = "Smartwatch con display Super AMOLED, tracciamento sonno e ECG",
    Image = "images/SamsungGalaxyWatch6.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("bb06d6a8-a8b1-4f21-bbe6-f8dc371a687e"),
    Name = "Kindle Paperwhite 11ª gen",
    CategoryId = cat2,
    Quantity = 16,
    Price = 159.99M,
    Producer = "Amazon",
    Description = "Lettore eBook impermeabile con luce regolabile e schermo antiriflesso da 6.8 pollici",
    Image = "images/KindlePaperwhite.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("80f2b221-2498-44c4-8ae5-6c8a35b80ff3"),
    Name = "Google Chromecast con Google TV",
    CategoryId = cat2,
    Quantity = 46,
    Price = 69.99M,
    Producer = "Google",
    Description = "Streaming in 4K HDR con telecomando e assistente vocale",
    Image = "images/GoogleChromecast.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("7b84e964-50f0-4a17-b4a2-026d7629a5c4"),
    Name = "Xiaomi Redmi Note 13",
    CategoryId = cat2,
    Quantity = 33,
    Price = 199.90M,
    Producer = "Xiaomi",
    Description = "Smartphone Android 6.6'' AMOLED 120Hz, 128GB, Fotocamera 108MP",
    Image = "images/XiaomiRedmiNote13.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("6cfa90ba-ba8e-4140-b4b6-0c82cc489973"),
    Name = "Echo Dot (5ª generazione)",
    CategoryId = cat2,
    Quantity = 34,
    Price = 64.99M,
    Producer = "Amazon",
    Description = "Smart speaker con Alexa e sensore di temperatura integrato",
    Image = "images/EchoDot(5_generazione).jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("072f737f-fe24-4607-8caf-0a0ce58f3ff0"),
    Name = "Samsung SSD 980 PRO 1TB NVMe",
    CategoryId = cat2,
    Quantity = 24,
    Price = 149.99M,
    Producer = "Samsung",
    Description = "SSD PCIe 4.0 M.2 ultra veloce per gaming e editing",
    Image = "images/SamsungSSD980PRO1TBNVMe.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("a6756a0c-3815-4a93-a667-a369f6aeb0f5"),
    Name = "Anker PowerCore 20000 mAh",
    CategoryId = cat2,
    Quantity = 15,
    Price = 49.99M,
    Producer = "Anker",
    Description = "Power bank ad alta capacità con doppia porta USB e ricarica rapida",
    Image = "images/AnkerPowerCore20000mAh.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("a2f205bc-27ea-418c-ba00-5e13b2b03885"),
    Name = "Logitech MX Master 3S",
    CategoryId = cat2,
    Quantity = 25,
    Price = 119.00M,
    Producer = "Logitech",
    Description = "Mouse wireless ergonomico con scorrimento elettromagnetico e sensore 8K DPI",
    Image = "images/LogitechMXMaster3S.jpg",
    IsBestSeller = false
},


//Elettrodomestici 
new Product
{
    Id = new Guid("f73b6f10-6a71-56f5-98f3-abded94bf571"),
    Name = "Moulinex Cookeo CE7041",
    CategoryId = cat3,
    Quantity = 15,
    Price = 199.99M,
    Producer = "Moulinex",
    Description = "Multicooker intelligente con 100 ricette integrate",
    Image = "images/MoulinexCookeo.jpg",
    IsBestSeller = true
},


new Product
{
    Id = new Guid("f62b5f09-5a60-45f4-97f2-abded93bf460"),
    Name = "Philips Airfryer XL Essential",
    CategoryId = cat3,
    Quantity = 18,
    Price = 129.99M,
    Producer = "Philips",
    Description = "Friggitrice ad aria da 6.2L con tecnologia Rapid Air per cucinare con poco olio",
    Image = "images/PhilipsAirfryerXLEssential.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("fd8ca21e-ad1b-458f-a8ad-ff3366acdea9"),
    Name = "De'Longhi Magnifica Start",
    CategoryId = cat3,
    Quantity = 21,
    Price = 319.99M,
    Producer = "De'Longhi",
    Description = "Macchina automatica per caffè in chicchi con pannarello e display soft touch",
    Image = "images/DeLonghiMagnificaStart.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("b9e38a4d-0d97-4652-b8d1-ea306ac0627e"),
    Name = "Imetec Scaldasonno Sensitive",
    CategoryId = cat3,
    Quantity = 30,
    Price = 79.90M,
    Producer = "Imetec",
    Description = "Coperta riscaldante matrimoniale con controllo temperatura e spegnimento automatico",
    Image = "images/ImetecScaldasonno.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("863b15aa-e0ab-4e4d-9349-e3cb085fb6a6"),
    Name = "Bosch Serie 2 Lavastoviglie",
    CategoryId = cat3,
    Quantity = 31,
    Price = 399.99M,
    Producer = "Bosch",
    Description = "Lavastoviglie da incasso 60 cm con 5 programmi e funzione ExtraDry",
    Image = "images/BoschSerie2Lavastoviglie.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("99f109ae-3033-4a83-9aef-8c1c1ce08b80"),
    Name = "Rowenta Compact Power XXL",
    CategoryId = cat3,
    Quantity = 20,
    Price = 109.00M,
    Producer = "Rowenta",
    Description = "Aspirapolvere con sacco, 4.5L, alta potenza e filtraggio avanzato",
    Image = "images/RowentaCompactPowerXXL.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("359bc919-86e3-431b-8b72-5b83018de709"),
    Name = "Moulinex Easy Force Robot da Cucina",
    CategoryId = cat3,
    Quantity = 50,
    Price = 89.99M,
    Producer = "Moulinex",
    Description = "Robot multifunzione da 700W con accessori inclusi per impastare, tritare e grattugiare",
    Image = "images/MoulinexEasyForceRobotdaCucina.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("76b79275-5642-4c40-9cd6-9360a1f16f11"),
    Name = "Hoover H-Free 100",
    CategoryId = cat3,
    Quantity = 15,
    Price = 159.99M,
    Producer = "Hoover",
    Description = "Scopa elettrica senza fili con autonomia fino a 40 minuti",
    Image = "images/HooverHFree100.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("b99f74d1-bb8a-4c0d-bcdf-bfb5060de4e1"),
    Name = "Beko Forno Ventilato BIE22300",
    CategoryId = cat3,
    Quantity = 34,
    Price = 299.99M,
    Producer = "Beko",
    Description = "Forno elettrico da incasso 71L, classe A, con funzione grill e display LED",
    Image = "images/BekoFornoVentilato.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("7c1a6983-a0f4-4971-bde8-ca1f5f4954ba"),
    Name = "Electrolux PerfectCare 600",
    CategoryId = cat3,
    Quantity = 30,
    Price = 469.00M,
    Producer = "Electrolux",
    Description = "Lavatrice 8kg, 1200 giri, tecnologia SensiCare per un bucato delicato",
    Image = "images/ElectroluxPerfectCare600.jpg",
    IsBestSeller = true
},

//Abbigliamento

new Product
{
    Id = new Guid("3a8c19f4-fda5-5f4e-a861-a2455dc4dd90"),
    Name = "Levi's 501 Original Jeans",
    CategoryId = cat4,
    Quantity = 35,
    Price = 89.00M,
    Producer = "Levi's",
    Description = "Jeans classico taglio dritto, denim blu",
    Image = "images/Levis501OriginalJeansDonna.jpg",
    IsBestSeller = true
},


new Product
{
    Id = new Guid("2a7c08f3-fda4-4f3e-a750-a1344dc3dd89"),
    Name = "Nike Dri-FIT Academy T-Shirt Uomo",
    CategoryId = cat4,
    Quantity = 22,
    Price = 27.99M,
    Producer = "Nike",
    Description = "T-shirt sportiva traspirante con tecnologia Dri-FIT",
    Image = "images/NikeDri-FITAcademyT-ShirtUomo.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("2d47f5dc-2bac-4ee7-b80b-a402ec6400c8"),
    Name = "Adidas Essentials Felpa Con Cappuccio",
    CategoryId = cat4,
    Quantity = 41,
    Price = 54.99M,
    Producer = "Adidas",
    Description = "Felpa con cappuccio in cotone misto, stile casual",
    Image = "images/AdidasEssentials.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("68f65a13-8fbc-4153-9283-e2126bb891be"),
    Name = "Levi's 501 Original Jeans Uomo",
    CategoryId = cat4,
    Quantity = 28,
    Price = 89.90M,
    Producer = "Levi's",
    Description = "Jeans classici regular fit in denim di alta qualità",
    Image = "images/Levis501OriginalJeans.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("a8efdc2c-d690-418c-8d8f-3f305edd3dba"),
    Name = "Puma Essentials Logo T-Shirt Donna",
    CategoryId = cat4,
    Quantity = 48,
    Price = 16.99M,
    Producer = "Puma",
    Description = "T-shirt con logo stampato, in cotone sostenibile",
    Image = "images/PumaT-ShirtDonna.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("7b45e7fa-d812-4d20-9579-324ec3ff92cd"),
    Name = "Calvin Klein Slip Uomo (3 Pezzi)",
    CategoryId = cat4,
    Quantity = 30,
    Price = 39.90M,
    Producer = "Calvin Klein",
    Description = "Set di slip in cotone elasticizzato con logo in vita",
    Image = "images/CalvinKleinSlipUomo(3Pezzi).jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("14d62de2-fa36-46d2-8b42-3422bfe3e058"),
    Name = "North Face Giacca Antipioggia Venture 2",
    CategoryId = cat4,
    Quantity = 20,
    Price = 129.00M,
    Producer = "The North Face",
    Description = "Giacca leggera e impermeabile con cuciture termosaldate",
    Image = "images/NorthFaceGiaccaVenture2.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("f8e191d5-b382-4508-b4f9-70f97b7df8eb"),
    Name = "Havaianas Brasil Logo Infradito",
    CategoryId = cat4,
    Quantity = 50,
    Price = 21.99M,
    Producer = "Havaianas",
    Description = "Infradito estive classiche, comode e colorate",
    Image = "images/HavaianasBrasilLogoInfradito.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("1f33cfa7-f52f-4076-8930-0f848b44cc34"),
    Name = "Tommy Hilfiger Polo Basic",
    CategoryId = cat4,
    Quantity = 23,
    Price = 44.90M,
    Producer = "Tommy Hilfiger",
    Description = "Polo elegante in piqué con logo ricamato",
    Image = "images/TommyHilfigerPoloBasic.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("8e68cb91-265e-4f9f-bc37-a7580e905e87"),
    Name = "Champion Felpa Girocollo Small Logo",
    CategoryId = cat4,
    Quantity = 16,
    Price = 39.90M,
    Producer = "Champion",
    Description = "Felpa in cotone pesante con logo sul petto",
    Image = "images/ChampionFelpa.jpg",
    IsBestSeller = true
},

//Tempo libero

new Product
{
    Id = new Guid("f171c52e-5b38-41a9-b05b-d8087b4d306f"),
    Name = "LEGO Star Wars X-Wing",
    CategoryId = cat5,
    Quantity = 10,
    Price = 54.99M,
    Producer = "LEGO",
    Description = "Modello da costruire del famoso X-Wing Starfighter",
    Image = "images/LEGOStarWarsX-Wing.jpg",
    IsBestSeller = true
},


new Product
{
    Id = new Guid("bb102144-a85e-4561-a18d-bbcb1060d2e1"),
    Name = "lego star wars x-wing fighter di luke skywalker 75301",
    CategoryId = cat5,
    Quantity = 27,
    Price = 164.05M,
    Producer = "LEGO",
    Description = "Modellino da Costruire di Astronave da Collezione con Supporto, Idea Regalo di Compleanno per Adulti, Uomo, Donna e Fan dell'Attacco dei Cloni",
    Image = "images/LEGOStarWars75404.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("a6c6f8da-1f4d-42b5-b1ae-15dc5f1a2301"),
    Name = "LEGO Creator 3-in-1 Super Robot",
    CategoryId = cat5,
    Quantity = 20,
    Price = 19.99M,
    Producer = "LEGO",
    Description = "Set 3-in-1 per costruire robot, drago o jet",
    Image = "images/LEGOCreator3-in-1.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("493334d1-8d12-494b-8485-ef912c907dc7"),
    Name = "Monopoly Classico Hasbro",
    CategoryId = cat5,
    Quantity = 35,
    Price = 29.90M,
    Producer = "Hasbro",
    Description = "Gioco da tavolo di compravendita di proprietà",
    Image = "images/MonopolyClassicoHasbro.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("4cc1a3cb-fde8-465a-a44f-86fef040cba4"),
    Name = "Puzzle Ravensburger 2000 Pezzi",
    CategoryId = cat5,
    Quantity = 18,
    Price = 16.95M,
    Producer = "Ravensburger",
    Description = "Puzzle 2000 pezzi, qualità premium",
    Image = "images/puzzle.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("01139b0c-abe7-4775-886c-753303db2a0e"),
    Name = "Set di Carte UNO Mattel",
    CategoryId = cat5,
    Quantity = 50,
    Price = 8.99M,
    Producer = "Mattel",
    Description = "Gioco di carte UNO classico per tutta la famiglia",
    Image = "images/CarteUNOMattel.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("f9ed47a1-d949-482e-83f0-c3b80c1e6f19"),
    Name = "Kendama Krom Pop",
    CategoryId = cat5,
    Quantity = 15,
    Price = 24.90M,
    Producer = "KROM",
    Description = "Gioco di abilità giapponese in legno colorato",
    Image = "images/KendamaKromPop.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("c6103378-7a02-449d-a53e-9fdf1d8d3ef9"),
    Name = "Set 3 Frisbee Aerobie Pro",
    CategoryId = cat5,
    Quantity = 28,
    Price = 17.50M,
    Producer = "Aerobie",
    Description = "Frisbee per sport all'aperto, lunga gittata",
    Image = "images/FrisbeeAerobiePro.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("e2794eca-7808-402c-83de-97a3b2e9d930"),
    Name = "Pallone da Calcio Adidas Tango",
    CategoryId = cat5,
    Quantity = 32,
    Price = 14.99M,
    Producer = "Adidas",
    Description = "Pallone resistente ideale per il tempo libero",
    Image = "images/PalloneAdidasTango.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("8e8b5685-1366-4e53-b99c-016f75bfaa09"),
    Name = "Diabolo Juggle Dream con Bastoncini",
    CategoryId = cat5,
    Quantity = 40,
    Price = 19.95M,
    Producer = "Juggle Dream",
    Description = "Diabolo per giocoleria con bastoncini in legno",
    Image = "images/DiaboloJuggleDreamBastoncini.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("8b0b2745-b584-4ec5-b293-91e692a48166"),
    Name = "Set Ping Pong Portatile JOOLA",
    CategoryId = cat5,
    Quantity = 19,
    Price = 24.99M,
    Producer = "JOOLA",
    Description = "Set completo con racchette, palline e rete da tavolo",
    Image = "images/SetPingPongPortatileJOOLA.jpg",
    IsBestSeller = true
},

//Attrezzatura sportiva
new Product
{
    Id = new Guid("0342134e-4a4d-4a26-8d3f-9955a2aa7d82"),
    Name = "Manubri Regolabili Bowflex SelectTech 552",
    CategoryId = cat6,
    Quantity = 15,
    Price = 399.00M,
    Producer = "Bowflex",
    Description = "Set di manubri regolabili da 2 a 24 kg",
    Image = "images/ManubriRegolabiliBowflexSelectTech552.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("05c44beb-5677-4cc8-93b5-a66197c1b2de"),
    Name = "Tappetino Yoga Manduka PRO",
    CategoryId = cat6,
    Quantity = 40,
    Price = 119.00M,
    Producer = "Manduka",
    Description = "Tappetino professionale antiscivolo per yoga",
    Image = "images/TappetinoYogaMandukaPRO.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("ffed2955-d6c1-4951-878f-a59ef6f96c2a"),
    Name = "Palla da Pilates Gaiam",
    CategoryId = cat6,
    Quantity = 30,
    Price = 21.99M,
    Producer = "Gaiam",
    Description = "Palla da ginnastica 65cm con pompa inclusa",
    Image = "images/PalladaPilatesGaiam.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("2f24edd3-3568-4d52-8757-4cbdcf432614"),
    Name = "Corda per Saltare Speed Rope BeMaxx",
    CategoryId = cat6,
    Quantity = 50,
    Price = 16.90M,
    Producer = "BeMaxx",
    Description = "Corda per salti rapidi regolabile in lunghezza",
    Image = "images/CordaXSaltareBeMaxx.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("3a44b124-e862-4080-bb84-de6a9b1c423e"),
    Name = "Rullo Massaggiante TriggerPoint GRID",
    CategoryId = cat6,
    Quantity = 25,
    Price = 38.90M,
    Producer = "TriggerPoint",
    Description = "Rullo foam per massaggi e rilascio miofasciale",
    Image = "images/RulloMassaggianteGRID.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("6c91be01-d178-4dc7-bfc3-26dc8bedca3b"),
    Name = "TRX Suspension Training Kit",
    CategoryId = cat6,
    Quantity = 12,
    Price = 139.00M,
    Producer = "TRX",
    Description = "Kit completo per allenamento in sospensione",
    Image = "images/TRXSuspensionTrainingKit.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("5cd30429-e765-4685-b327-ec48434bdc87"),
    Name = "Kettlebell in Ghisa PROIRON 12kg",
    CategoryId = cat6,
    Quantity = 18,
    Price = 39.90M,
    Producer = "PROIRON",
    Description = "Kettlebell classico per cross training e forza",
    Image = "images/Kettlebell12kg.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("057beaa9-5f4c-43e3-8b5d-d5eca661439b"),
    Name = "Panca Piana Adidas Performance",
    CategoryId = cat6,
    Quantity = 10,
    Price = 99.99M,
    Producer = "Adidas",
    Description = "Panca da allenamento stabile e robusta",
    Image = "images/PancaPianaPerformance.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("5171273c-570d-4642-b5a3-81e0050e0331"),
    Name = "Set Elastici di Resistenza FitBeast",
    CategoryId = cat6,
    Quantity = 35,
    Price = 29.99M,
    Producer = "FitBeast",
    Description = "5 fasce elastiche con maniglie e accessori",
    Image = "images/SetElastici.jpg",
    IsBestSeller = true
},

//Amici animali

new Product
{
    Id = new Guid("64462dc7-2faa-4f1c-9769-2a283deafca7"),
    Name = "Royal Canin Maxi Adult 15kg",
    CategoryId = cat7,
    Quantity = 20,
    Price = 64.99M,
    Producer = "Royal Canin",
    Description = "Crocchette per cani adulti di taglia grande",
    Image = "images/RoyalCanin15kg.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("1ae30f94-92bc-4316-9346-58a612ae32f0"),
    Name = "Purina One Sterilcat 3kg",
    CategoryId = cat7,
    Quantity = 35,
    Price = 16.99M,
    Producer = "Purina",
    Description = "Alimento completo per gatti sterilizzati",
    Image = "images/Purina3kg.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("ce7b2cbd-2b63-4381-8ef2-4b75bca3a02c"),
    Name = "Tiragraffi Relax per Gatti",
    CategoryId = cat7,
    Quantity = 12,
    Price = 44.90M,
    Producer = "FEANDREA",
    Description = "Tiragraffi a torre con cuccia e piattaforme",
    Image = "images/TiragraffiGatti.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("ad74ed2d-5c36-4138-9ffb-dd393587cb6b"),
    Name = "Cuccia Morbida Amazon Basics",
    CategoryId = cat7,
    Quantity = 28,
    Price = 24.99M,
    Producer = "Amazon Basics",
    Description = "Cuccia soffice per cani e gatti, lavabile",
    Image = "images/CucciaMorbidaAmazon.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("1a343040-4549-452d-a714-b6a0ef576c16"),
    Name = "Dispenser Automatico Cibo Petkit",
    CategoryId = cat7,
    Quantity = 10,
    Price = 89.90M,
    Producer = "Petkit",
    Description = "Dispenser automatico smart per cani e gatti",
    Image = "images/DispenserCiboPetkit.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("210f8b92-08ee-41cc-ae74-98c60f21849f"),
    Name = "Spazzola Autopulente per Animali",
    CategoryId = cat7,
    Quantity = 50,
    Price = 14.50M,
    Producer = "Pecute",
    Description = "Spazzola con setole retraibili per la toelettatura",
    Image = "images/SpazzolaAnimali.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("c6ea7f07-49ec-4970-924f-907b306370c7"),
    Name = "Gioco Interattivo Kong Classic",
    CategoryId = cat7,
    Quantity = 60,
    Price = 9.99M,
    Producer = "Kong",
    Description = "Gioco in gomma per cani da riempire con snack",
    Image = "images/GiocoKongClassic.jpg",
    IsBestSeller = true
},

new Product
{
    Id = new Guid("d7f9d020-e965-4461-8894-a7b8ec7a7af5"),
    Name = "Trasportino Morbido Trixie",
    CategoryId = cat7,
    Quantity = 18,
    Price = 32.99M,
    Producer = "Trixie",
    Description = "Borsa per il trasporto di animali di piccola taglia",
    Image = "images/trasportinoTrixie.jpg",
    IsBestSeller = false
},

new Product
{
    Id = new Guid("d1e09e9a-1cca-4ba8-b93d-8d49d34583ad"),
    Name = "Fontanella Acqua Catit Flower",
    CategoryId = cat7,
    Quantity = 25,
    Price = 27.50M,
    Producer = "Catit",
    Description = "Fontanella a fiore per gatti, stimola l’idratazione",
    Image = "images/FontanellaAcquaFlower.jpg",
    IsBestSeller = true




},
// ...Tuo codice precedente

// --- NUOVI PRODOTTI AGGIUNTI ALLA FINE DI OGNI CATEGORIA ---
// Cosmetici
new Product
{
    Id = new Guid("25c84f27-dab1-4dc1-a5eb-77335f0e3fdf"),
    Name = "Detergente Viso Delicato",
    CategoryId = cat1,
    Quantity = 20,
    Price = 7.99M,
    Producer = "Bionike",
    Description = "Detergente schiumogeno per tutti i tipi di pelle.",
    Image = "images/bionike.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("b2a7ae52-915f-4563-9d4f-accf256968f0"),
    Name = "Struccante Occhi",
    CategoryId = cat1,
    Quantity = 15,
    Price = 5.99M,
    Producer = "Garnier",
    Description = "Struccante bifasico per occhi sensibili.",
    Image = "images/garnierStruc.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("6a17b20e-2e8e-4b64-925c-43abfc5d24c0"),
    Name = "Siero Viso Vitamina C",
    CategoryId = cat1,
    Quantity = 12,
    Price = 19.50M,
    Producer = "Collistar",
    Description = "Siero illuminante anti-macchia.",
    Image = "images/vitaminac.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("36dbf436-d4ec-47ab-bea2-3b0df6d90dc2"),
    Name = "Maschera Idratante Notte",
    CategoryId = cat1,
    Quantity = 18,
    Price = 13.90M,
    Producer = "Sephora",
    Description = "Maschera notte super idratante.",
    Image = "images/maskcream.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("2e6b9b13-d9a1-4116-9c48-81ebf87e6f3e"),
    Name = "Burro Cacao Nutriente",
    CategoryId = cat1,
    Quantity = 30,
    Price = 3.99M,
    Producer = "Lycia",
    Description = "Protegge le labbra dal freddo.",
    Image = "images/lipgloss.jpg",
    IsBestSeller = false
},

// Tecnologia
new Product
{
    Id = new Guid("8162ea1f-760c-40eb-9acd-8699ae5154a9"),
    Name = "Mouse Wireless Ergonomico",
    CategoryId = cat2,
    Quantity = 25,
    Price = 29.90M,
    Producer = "Trust",
    Description = "Mouse wireless per lavoro e gaming.",
    Image = "images/mousetrust.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("1b4962eb-a1c7-430a-84b0-3c2a48f8519f"),
    Name = "Lampadina Smart WiFi",
    CategoryId = cat2,
    Quantity = 60,
    Price = 14.99M,
    Producer = "TP-Link",
    Description = "Lampadina led gestibile da smartphone.",
    Image = "images/lampadina.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("ceef3dd1-7296-4b63-835a-7f7293da75a1"),
    Name = "Webcam HD 1080p",
    CategoryId = cat2,
    Quantity = 40,
    Price = 49.99M,
    Producer = "Logitech",
    Description = "Webcam USB con microfono integrato.",
    Image = "images/icam.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("fd431bda-ed44-4dba-bd2d-dc2ac79326b8"),
    Name = "Power Bank 10000mAh",
    CategoryId = cat2,
    Quantity = 32,
    Price = 21.50M,
    Producer = "Anker",
    Description = "Batteria portatile ricarica rapida.",
    Image = "images/powerbank2.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("602e1072-56f6-43b8-b349-460513fc01ab"),
    Name = "Speaker Bluetooth Portatile",
    CategoryId = cat2,
    Quantity = 45,
    Price = 18.99M,
    Producer = "JBL",
    Description = "Mini speaker per ascolto musicale ovunque.",
    Image = "images/cassaJbl.jpg",
    IsBestSeller = false
},

// Elettrodomestici
new Product
{
    Id = new Guid("f4b15084-8dbb-47b6-8614-a83f390aa9b6"),
    Name = "Tostapane 2 Fette",
    CategoryId = cat3,
    Quantity = 20,
    Price = 24.90M,
    Producer = "Imetec",
    Description = "Tostapane compatto con espulsione automatica.",
    Image = "images/tostapane.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("4e145c19-e470-40d5-bd5a-5b08ae8146c4"),
    Name = "Macchina Caffè Espresso",
    CategoryId = cat3,
    Quantity = 17,
    Price = 69.00M,
    Producer = "De'Longhi",
    Description = "Macchina manuale per caffè macinato.",
    Image = "images/deLonghi.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("b045a87c-4b52-49d2-b5b1-81a53c6dae4b"),
    Name = "Aspirabriciole Ricaricabile",
    CategoryId = cat3,
    Quantity = 28,
    Price = 35.00M,
    Producer = "Rowenta",
    Description = "Aspirabriciole portatile senza filo.",
    Image = "images/aspirabriciole.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("7cafab9b-e7c5-4659-bfdc-b0d60ed9189c"),
    Name = "Forno a Microonde 20L",
    CategoryId = cat3,
    Quantity = 13,
    Price = 79.90M,
    Producer = "Samsung",
    Description = "Microonde digitale con funzione grill.",
    Image = "images/microonde.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("ec5941df-48f2-45f5-800b-8dda367e224b"),
    Name = "Ventilatore a Piantana",
    CategoryId = cat3,
    Quantity = 22,
    Price = 36.90M,
    Producer = "Ardes",
    Description = "Ventilatore silenzioso regolabile in altezza.",
    Image = "images/ventilatore.jpg",
    IsBestSeller = false
},

// Abbigliamento
new Product
{
    Id = new Guid("c3ed6e3c-f498-4d8e-aad0-48731b9a9fbb"),
    Name = "T-Shirt Basic Bianca",
    CategoryId = cat4,
    Quantity = 44,
    Price = 9.99M,
    Producer = "Fruit of the Loom",
    Description = "Maglietta cotone uomo/donna.",
    Image = "images/fruitoftheloom.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("6096d5dc-a3f9-41d5-b8dc-2edbfb3a75e6"),
    Name = "Pantaloncini Sportivi",
    CategoryId = cat4,
    Quantity = 35,
    Price = 14.99M,
    Producer = "Adidas",
    Description = "Shorts traspiranti per allenamento.",
    Image = "images/pantaloncini.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("d72e67a8-3ad0-42d6-a509-a7d5fd1176e7"),
    Name = "Cappellino con Visiera",
    CategoryId = cat4,
    Quantity = 25,
    Price = 8.50M,
    Producer = "Nike",
    Description = "Cappellino regolabile, vari colori.",
    Image = "images/cappellinoNike.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("73faa235-715f-4f09-86e9-388db8689da2"),
    Name = "Sciarpa Lana Unisex",
    CategoryId = cat4,
    Quantity = 15,
    Price = 19.90M,
    Producer = "Benetton",
    Description = "Sciarpa in lana calda.",
    Image = "images/Sciarpa.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("7b14cdea-69e1-4c72-b2ef-ee0dd95e091f"),
    Name = "Sneakers Casual Blu",
    CategoryId = cat4,
    Quantity = 19,
    Price = 45.90M,
    Producer = "Converse",
    Description = "Scarpe basse blu stile casual.",
    Image = "images/converse.jpg",
    IsBestSeller = false
},

// Tempo Libero
new Product
{
    Id = new Guid("f3f25433-cb03-493c-a773-25aef3a80bd0"),
    Name = "Set Tennis da Tavolo",
    CategoryId = cat5,
    Quantity = 18,
    Price = 22.50M,
    Producer = "JOOLA",
    Description = "Set 2 racchette, 3 palline e rete.",
    Image = "images/pingpong.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("0d3799fc-7168-4f17-a35b-39eda9459eae"),
    Name = "Kit Pittura Acrilica",
    CategoryId = cat5,
    Quantity = 12,
    Price = 17.90M,
    Producer = "Giotto",
    Description = "Set 12 colori acrilici per hobby creativi.",
    Image = "images/kitPittura.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("7dad40f9-dcec-436f-a854-029ee217d500"),
    Name = "Puzzle 2000 Pezzi",
    CategoryId = cat5,
    Quantity = 10,
    Price = 15.99M,
    Producer = "Clementoni",
    Description = "Puzzle paesaggio di Venezia.",
    Image = "images/Puzzle–Venezia.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("ed95dc2e-8168-44ec-ae9b-c6ad3dfcb1b2"),
    Name = "Gioco di Carte Scopa",
    CategoryId = cat5,
    Quantity = 26,
    Price = 4.99M,
    Producer = "Dal Negro",
    Description = "Carte da gioco classiche italiane.",
    Image = "images/CarteGioco.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("4971cff6-b843-4af1-a69b-714823a5155e"),
    Name = "Monopattino per Bambini",
    CategoryId = cat5,
    Quantity = 8,
    Price = 29.99M,
    Producer = "Globber",
    Description = "Monopattino pieghevole per bambini 5+.",
    Image = "images/monopattino.jpg",
    IsBestSeller = false
},

// Attrezzatura sportiva
new Product
{
    Id = new Guid("59c48d4d-fad7-4d70-b5bd-79e7b41e37cb"),
    Name = "Guanti Fitness Antiscivolo",
    CategoryId = cat6,
    Quantity = 35,
    Price = 12.50M,
    Producer = "Domyos",
    Description = "Guanti per sollevamento pesi.",
    Image = "images/GuantiBuilder.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("a3e980f4-f4d1-4245-8cd1-2bf17e509ee6"),
    Name = "Palla Basket Outdoor",
    CategoryId = cat6,
    Quantity = 18,
    Price = 21.90M,
    Producer = "Molten",
    Description = "Pallone basket per esterni.",
    Image = "images/PalloneBasket.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("62b958ca-6bef-482f-bc20-2e915aa4ce94"),
    Name = "Cintura Running Porta Cellulare",
    CategoryId = cat6,
    Quantity = 29,
    Price = 9.99M,
    Producer = "Kalenji",
    Description = "Cintura elastica regolabile con tasca.",
    Image = "images/PortaCel.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("c62e92cf-bbcf-45e4-b005-5424ddcc6518"),
    Name = "Fascia Polso Traspirante",
    CategoryId = cat6,
    Quantity = 16,
    Price = 6.99M,
    Producer = "Nike",
    Description = "Fascia per polso assorbente per lo sport.",
    Image = "images/polsinonike.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("309d258d-5256-4799-8efe-ae975f282d38"),
    Name = "Elastico Fitness Circolare",
    CategoryId = cat6,
    Quantity = 40,
    Price = 4.90M,
    Producer = "Decathlon",
    Description = "Fascia elastica per esercizi di tonificazione.",
    Image = "images/SetElastici.jpg",
    IsBestSeller = false
},

// Amici animali
new Product
{
    Id = new Guid("26bf5eed-1c64-4628-8d2f-78eba724b441"),
    Name = "Snack per Cani al Manzo",
    CategoryId = cat7,
    Quantity = 40,
    Price = 2.90M,
    Producer = "Pedigree",
    Description = "Snack masticabili gusto manzo per cani adulti.",
    Image = "images/SnackCani.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("7fa7ebfd-e136-46d8-889a-2b41cab07e19"),
    Name = "Tiragraffi Mini",
    CategoryId = cat7,
    Quantity = 13,
    Price = 12.99M,
    Producer = "Trixie",
    Description = "Tiragraffi compatto per gatti cuccioli.",
    Image = "images/Tiragraffi.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("a080148f-a46f-4204-b9ba-57c011a6faf6"),
    Name = "Ciotola Doppia in Acciaio",
    CategoryId = cat7,
    Quantity = 20,
    Price = 7.90M,
    Producer = "Ferplast",
    Description = "Ciotola per cibo e acqua, antiscivolo.",
    Image = "images/CiotolaXcibo.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("db33e815-7ecd-44e9-93a8-fcda641c9455"),
    Name = "Guinzaglio Retrattile 5m",
    CategoryId = cat7,
    Quantity = 21,
    Price = 14.50M,
    Producer = "Flexi",
    Description = "Guinzaglio per cani con estensione 5 metri.",
    Image = "images/Guinzaglio.jpg",
    IsBestSeller = false
},
new Product
{
    Id = new Guid("3674aaf0-5928-47ab-9afd-6deebfc5656f"),
    Name = "Set Toelettatura Base",
    CategoryId = cat7,
    Quantity = 15,
    Price = 10.90M,
    Producer = "Petkit",
    Description = "Set spazzole e forbicine per la cura del pelo.",
    Image = "images/SetSpazzoleForbicine.jpg",
    IsBestSeller = false
}
);
        }
    }
}


