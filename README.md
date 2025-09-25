
# 🛒 IBuy - E-Commerce React + ASP.NET Core

![GitHub last commit](https://img.shields.io/github/last-commit/M4nu3l4/IBuy?style=flat-square)
![GitHub repo size](https://img.shields.io/github/repo-size/M4nu3l4/IBuy?style=flat-square)


**IBuy** è una moderna piattaforma E-Commerce full-stack sviluppata come progetto capstone da [Manuela Lissia]. L'applicazione consente ad utenti registrati e non di navigare, selezionare, acquistare e gestire ordini in modo sicuro e intuitivo.

---

## 📌 Caratteristiche principali

- ✅ Navigazione e ricerca prodotti anche da utenti non loggati
- ✅ Registrazione e Login utente con JWT + Ruoli (Cliente, AdminFE, AdminBE, AdminOffice)
- ✅ Gestione carrello, wishlist, ordini e resi
- ✅ Sistema coupon sconto e credito cliente
- ✅ Email conferma registrazione e acquisto con Mailjet
- ✅ Interfaccia responsive e user-friendly con Bootstrap 5
- ✅ Dashboard amministrativa per gestione prodotti, utenti e ruoli
- ✅ Logging, gestione errori, middleware di sicurezza

---

## 🧱 Architettura Tecnologica

| Livello | Tecnologia |
|--------|------------|
| Frontend | React, Bootstrap, React Router, Axios |
| Backend | ASP.NET Core Web API, Entity Framework Core |
| Database | Microsoft SQL Server |
| Autenticazione | ASP.NET Core Identity + JWT |
| Email | Mailjet API |
| Hosting | Localhost, pronto per deploy in ambiente cloud |
| Logging | Console + Debug Provider |

---

## 🎯 Obiettivo del progetto

> Realizzare un portale e-commerce completo che:
>
> - Permetta all’utente di registrarsi e ricevere un **codice sconto personalizzato**
> - Offra la possibilità di **navigare da guest**, accedere a dettagli e filtrare i prodotti
> - Consenta la **gestione del carrello**, wishlist e pagamenti simulati
> - Supporti la gestione dei **resi, ordini e annullamenti**
> - Offra **pannelli dedicati ai vari ruoli** per la gestione operativa

---

## 👥 Ruoli previsti

- **Cliente**: può registrarsi, acquistare, restituire, annullare ordini
- **AdminOffice**: assegna ruoli, gestisce utenti e verifica la piattaforma
- **AdminFE**: lavora sull’interfaccia utente e l’esperienza front-end
- **AdminBE**: gestisce flussi dati, prodotti, categorie e backend logic

---

## ✉️ Invio Email

- Registrazione → invio email conferma + codice promo sconto
- Acquisto → riepilogo ordine via email
- Reso → conferma gestione reso
- Annullamento → avviso annullamento con eventuale rimborso

---

## 💾 Database & Modelli

Le principali tabelle:

- `User`, `Product`, `Order`, `OrderDetail`, `Transaction`
- `Coupon`, `Wishlist`, `ContactRequest`, `JobApplication`

Supporta **relazioni complete**, vincoli FK e precisione sui prezzi.

---

## 🖼️ Interfaccia Grafica

- **Navbar dinamica**: cambia dopo login con saluto personalizzato, dropdown account, icona carrello
- **Home accessibile**: anche per guest → visualizzazione card prodotti e categorie
- **Search + Carousel**: filtraggio prodotti per nome/categoria, carosello con best seller
- **Dettaglio prodotto**: pagina con descrizione estesa, disponibilità, prezzo
- **Modali intuitive**: login, conferma registrazione, conferma acquisto
- **Footer**: contatti, sede legale, social, lavora con noi, privacy

---

## 🔐 Sicurezza

- JWT per autenticazione e accesso sicuro
- Policy per autorizzare accesso in base ai ruoli
- Validazioni e gestione errori lato server
- Logging automatico con dettagli richieste

---

## 🧪 Funzionalità in sviluppo

- [ ] Statistiche guadagno per categoria e periodo
- [ ] Sistema recensioni
- [ ] Admin Dashboard con visualizzazione metriche
- [ ] Integrazione pagamento reali (es. Stripe o PayPal)

---

## 🛠️ Come avviare il progetto

### Backend (ASP.NET Core API)

```bash
cd IBuy.API
dotnet restore
dotnet ef database update
dotnet run
Frontend (React)
bash

cd IBuyFE
npm install
npm run dev
📸 Screenshots e prototipi
⚠️ Se desideri, puoi inserire immagini e link ai prototipi direttamente in questa sezione

🤝 Contribuisci
Per suggerimenti o bug apri una issue o invia una pull request!
📧 Email contatto: infoclienti@ibuy.com

© 2024 IBuy Srl
Tutti i diritti riservati.
Privacy & GDPR | Lavora con noi | Area admin
