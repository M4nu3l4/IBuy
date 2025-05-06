import React, { useEffect, useState } from "react";
import axios from "../utils/axiosConfig";

function GestioneOrdini() {
  const [ordini, setOrdini] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");
  const [success, setSuccess] = useState("");

  useEffect(() => {
    const fetchOrdini = async () => {
      try {
        const res = await axios.get("/purchase/all-orders");
        setOrdini(res.data);
      } catch (err) {
        setError("Errore nel recupero ordini.");
      } finally {
        setLoading(false);
      }
    };
    fetchOrdini();
  }, []);

  const handleAzione = async (id, tipo) => {
    try {
      await axios.put(`/purchase/${tipo}/${id}`);
      setOrdini((prev) => prev.filter((o) => o.id !== id));
      setSuccess(`Ordine ${tipo === "cancel" ? "annullato" : "restituito"} con successo`);
      setTimeout(() => setSuccess(""), 3000);
    } catch (err) {
      setError("Errore durante l'operazione.");
      setTimeout(() => setError(""), 3000);
    }
  };

  if (loading) return <div className="container my-5">Caricamento ordini...</div>;

  return (
    <div className="container my-5">
      <h2>Gestione Ordini</h2>
      {error && <div className="alert alert-danger">{error}</div>}
      {success && <div className="alert alert-success">{success}</div>}

      {ordini.length === 0 ? (
        <p>Nessun ordine da gestire.</p>
      ) : (
        <div className="table-responsive">
          <table className="table table-striped table-hover">
            <thead>
              <tr>
                <th>Prodotto</th>
                <th>Quantità</th>
                <th>Importo</th>
                <th>Email Cliente</th>
                <th>Data</th>
                <th>Azioni</th>
              </tr>
            </thead>
            <tbody>
              {ordini.map((ord) => (
                <tr key={ord.id}>
                  <td>{ord.productName}</td>
                  <td>{ord.quantity}</td>
                  <td>{ord.amount.toFixed(2)} €</td>
                  <td>{ord.userEmail}</td>
                  <td>{new Date(ord.date).toLocaleString()}</td>
                  <td>
                    <button
                      className="btn btn-outline-danger btn-sm me-2"
                      onClick={() => handleAzione(ord.id, "cancel")}
                    >
                      Annulla
                    </button>
                    <button
                      className="btn btn-outline-warning btn-sm"
                      onClick={() => handleAzione(ord.id, "return")}
                    >
                      Reso
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
}

export default GestioneOrdini;
