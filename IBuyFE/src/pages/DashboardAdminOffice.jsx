// src/pages/DashboardAdminOffice.jsx
import React, { useEffect, useState } from "react";
import axios from "axios";

function DashboardAdminOffice() {
  const [guadagno, setGuadagno] = useState(null);
  const [ordini, setOrdini] = useState([]);
  const [error, setError] = useState("");
  const [user, setUser] = useState(null);

  useEffect(() => {
    
    const userData = JSON.parse(localStorage.getItem("user"));
    setUser(userData);

    
    if (!userData || !userData.token) {
      setError("Utente non autenticato!");
      return;
    }
    if (!userData.roles || !userData.roles.includes("AdminOffice")) {
      setError("Non autorizzato. Solo AdminOffice può accedere a questa pagina.");
      return;
    }
  
    const headers = { Authorization: `Bearer ${userData.token}` };

    // Guadagno totale
    axios.get("https://localhost:7279/api/Stats/guadagno-totale", { headers })
      .then(res => setGuadagno(res.data.guadagnoTotale))
      .catch(() => setError("Errore nel caricamento del guadagno totale"));

    // Lista movimenti/ordini
    axios.get("https://localhost:7279/api/Stats/movimenti", { headers })
      .then(res => setOrdini(res.data))
      .catch(() => setError("Errore nel caricamento ordini"));
  }, []);

  
  if (error && (error.includes("autorizzato") || error.includes("autenticato"))) {
    return (
      <div className="container my-5">
        <div className="alert alert-danger">{error}</div>
      </div>
    );
  }

  return (
    <div className="container my-5">
      <h1 className="mb-4">Dashboard Amministratore Ufficio</h1>
      {error && <div className="alert alert-danger">{error}</div>}

      <div className="card mb-4 p-3">
        <h4>Guadagno Totale</h4>
        <p className="fs-3 text-success">
          {guadagno !== null
            ? guadagno.toLocaleString("it-IT", { style: "currency", currency: "EUR" })
            : "--"}
        </p>
      </div>

      <div className="card p-3">
        <h4>Ultimi Ordini / Movimenti</h4>
        <div className="table-responsive">
          <table className="table table-striped table-hover">
            <thead>
              <tr>
                <th>Data</th>
                <th>Prodotto</th>
                <th>Tipo</th>
                <th>Quantità</th>
                <th>Importo (€)</th>
                <th>Email Cliente</th>
              </tr>
            </thead>
            <tbody>
              {ordini.length === 0 && (
                <tr>
                  <td colSpan="6" className="text-center">Nessun ordine disponibile.</td>
                </tr>
              )}
              {ordini.map((o) => (
                <tr key={o.id}>
                  <td>{new Date(o.timestamp || o.date).toLocaleString()}</td>
                  <td>{o.product ? o.product.name : "-"}</td>
                  <td>{o.type}</td>
                  <td>{o.quantity}</td>
                  <td>{o.amount.toLocaleString("it-IT", { style: "currency", currency: "EUR" })}</td>
                  <td>{o.userEmail}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}

export default DashboardAdminOffice;
