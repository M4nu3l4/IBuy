// src/pages/Privacy.jsx
import React from "react";

const Privacy = () => (
  <div className="container my-5 py-4 bg-white rounded shadow" style={{ maxWidth: 900 }}>
    <h2 className="mb-4 text-center">Informativa Privacy & GDPR</h2>
    <p>
      <strong>Ultimo aggiornamento:</strong> 23 aprile 2025
    </p>
    <p>
      Benvenuto su <strong>IBuy</strong>. La tua privacy è una nostra priorità. Questa informativa spiega come raccogliamo, usiamo, condividiamo e proteggiamo i tuoi dati personali in conformità al Regolamento UE 2016/679 (“GDPR”).
    </p>

    <h4 className="mt-4">1. Titolare del trattamento</h4>
    <p>
      IBuy Srl – Sede legale: Cagliari <br />
      P.IVA: 000024681012 <br />
      Email: info@ibuy.com
    </p>

    <h4 className="mt-4">2. Dati personali trattati</h4>
    <ul>
      <li><strong>Dati identificativi:</strong> nome, cognome, indirizzo email, telefono, indirizzo di spedizione/fatturazione.</li>
      <li><strong>Dati di accesso:</strong> username, password (criptata).</li>
      <li><strong>Dati relativi agli acquisti:</strong> prodotti acquistati, importi, cronologia ordini.</li>
      <li><strong>Dati tecnici:</strong> indirizzo IP, dati di navigazione (tramite cookie tecnici e analytics anonimizzati).</li>
    </ul>

    <h4 className="mt-4">3. Finalità e base giuridica</h4>
    <ul>
      <li>Gestione ordini, pagamenti e spedizioni</li>
      <li>Registrazione e autenticazione utenti</li>
      <li>Gestione area personale, carrello e lista desideri</li>
      <li>Invio di email di conferma e assistenza clienti</li>
      <li>Adempimenti di legge e obblighi fiscali</li>
      <li>Analisi statistiche anonime per migliorare il servizio</li>
      <li>Marketing diretto solo previo consenso esplicito</li>
    </ul>

    <h4 className="mt-4">4. Conservazione dei dati</h4>
    <p>
      I dati personali sono conservati solo per il tempo necessario al raggiungimento delle finalità indicate e per adempiere agli obblighi legali e fiscali. Gli account inattivi possono essere cancellati su richiesta dell’utente.
    </p>

    <h4 className="mt-4">5. Destinatari dei dati</h4>
    <ul>
      <li>Società di spedizione e corrieri per la consegna degli ordini</li>
      <li>Fornitori di servizi tecnici e hosting (server in UE)</li>
      <li>Consulenti legali, contabili e fiscali</li>
      <li><strong>I dati NON saranno mai venduti a terzi</strong> per finalità di marketing senza consenso.</li>
    </ul>

    <h4 className="mt-4">6. Diritti dell’utente</h4>
    <p>Ai sensi del GDPR puoi esercitare i seguenti diritti:</p>
    <ul>
      <li>Accesso, rettifica e cancellazione dei tuoi dati</li>
      <li>Limitazione o opposizione al trattamento</li>
      <li>Portabilità dei dati</li>
      <li>Revoca del consenso (in qualsiasi momento)</li>
      <li>Proporre reclamo al Garante Privacy</li>
    </ul>
    <p>
      Per qualsiasi richiesta puoi contattarci all’email: <a href="mailto:info@ibuy.com">info@ibuy.com</a>
    </p>

    <h4 className="mt-4">7. Cookie Policy</h4>
    <p>
      Questo sito utilizza solo cookie tecnici e, in forma aggregata, cookie analytics anonimi. Non viene effettuato profilazione senza consenso.
    </p>

    <h4 className="mt-4">8. Aggiornamenti</h4>
    <p>
      La presente informativa può essere soggetta a modifiche. Ti invitiamo a consultarla periodicamente.
    </p>
    <hr />
    <div className="text-center">
      <strong>Grazie per aver scelto IBuy!</strong>
    </div>
  </div>
);

export default Privacy;
