import React, { useEffect, useState } from "react";
import axios from "../utils/axiosConfig";
import { format } from "date-fns";

function AdminOrders() {
  const [orders, setOrders] = useState([]);
  const [filteredOrders, setFilteredOrders] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");
  const [success, setSuccess] = useState("");
  const [filterStatus, setFilterStatus] = useState("Tutti");

  useEffect(() => {
    fetchOrders();
  }, []);

  useEffect(() => {
    if (filterStatus === "Tutti") {
      setFilteredOrders(orders);
    } else {
      setFilteredOrders(orders.filter(o => o.orderStatus === filterStatus));
    }
  }, [orders, filterStatus]);

  const fetchOrders = async () => {
    try {
      const res = await axios.get("/purchase/all-orders");
      setOrders(res.data);
    } catch (err) {
      setError("Errore nel caricamento degli ordini.");
    } finally {
      setLoading(false);
    }
  };

  const handleAction = async (id, action) => {
    try {
      const res = await axios.put(`/purchase/${action}/${id}`);
      setSuccess(res.data.message);
      fetchOrders();
    } catch (err) {
      setError(`Errore durante l'operazione di ${action}`);
    }
  };

  const exportCSV = () => {
    const headers = ["Prodotto", "Quantità", "Totale", "Email Cliente", "Tipo", "Data", "Stato"];
    const rows = orders.map(o => [
      o.product.name,
      o.quantity,
      `${o.amount.toFixed(2)} €`,
      o.userEmail,
      o.type,
      format(new Date(o.date), "dd/MM/yyyy HH:mm"),
      o.orderStatus
    ]);
    const csvContent = [headers, ...rows].map(e => e.join(",")).join("\n");
    const blob = new Blob([csvContent], { type: "text/csv;charset=utf-8;" });
    const link = document.createElement("a");
    link.href = URL.createObjectURL(blob);
    link.download = "ordini.csv";
    link.click();
  };

  const renderBadge = (status) => {
    switch (status) {
      case "Attivo":
        return <span className="badge bg-success">{status}</span>;
      case "Annullato":
        return <span className="badge bg-danger">{status}</span>;
      case "Reso":
        return <span className="badge bg-secondary">{status}</span>;
      default:
        return <span className="badge bg-dark">{status}</span>;
    }
  };

  if (loading) return <div className="container my-5">Caricamento ordini...</div>;

  return (
    <div className="container my-5">
      <h2>Gestione Ordini</h2>
      {error && <div className="alert alert-danger">{error}</div>}
      {success && <div className="alert alert-success">{success}</div>}

      <div className="d-flex justify-content-between align-items-center mb-3">
        <div>
          <label className="me-2">Filtra per stato:</label>
          <select
            className="form-select d-inline-block w-auto"
            value={filterStatus}
            onChange={(e) => setFilterStatus(e.target.value)}
          >
            <option value="Tutti">Tutti</option>
            <option value="Attivo">Attivo</option>
            <option value="Annullato">Annullato</option>
            <option value="Reso">Reso</option>
          </select>
        </div>
        <button className="btn btn-outline-primary" onClick={exportCSV}>
          Esporta CSV
        </button>
      </div>

      {filteredOrders.length === 0 ? (
        <div className="alert alert-info">Nessun ordine disponibile.</div>
      ) : (
        <table className="table table-bordered align-middle">
          <thead>
            <tr>
              <th>Prodotto</th>
              <th>Quantità</th>
              <th>Totale</th>
              <th>Email Cliente</th>
              <th>Tipo</th>
              <th>Data</th>
              <th>Stato</th>
              <th>Azioni</th>
            </tr>
          </thead>
          <tbody>
            {filteredOrders.map((order) => (
              <tr key={order.id}>
                <td>{order.product.name}</td>
                <td>{order.quantity}</td>
                <td>{order.amount.toFixed(2)} €</td>
                <td>{order.userEmail}</td>
                <td>{order.type}</td>
                <td>{format(new Date(order.date), "dd/MM/yyyy HH:mm")}</td>
                <td>{renderBadge(order.orderStatus)}</td>
                <td className="d-flex gap-2">
                  <button
                    className="btn btn-warning btn-sm"
                    disabled={order.orderStatus !== "Attivo"}
                    onClick={() => handleAction(order.id, "cancel")}
                  >
                    Annulla
                  </button>
                  <button
                    className="btn btn-secondary btn-sm"
                    disabled={order.orderStatus !== "Attivo"}
                    onClick={() => handleAction(order.id, "return")}
                  >
                    Reso
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}

export default AdminOrders;
