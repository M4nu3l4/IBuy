import React, { useEffect, useState } from "react";
import axios from "../utils/axiosConfig";
import { Modal, Button, Form } from "react-bootstrap";

function Orders() {
  const [orders, setOrders] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");
  const [showModal, setShowModal] = useState(false);
  const [selectedOrderId, setSelectedOrderId] = useState(null);
  const [selectedAction, setSelectedAction] = useState("");
  const [note, setNote] = useState("");
  const [success, setSuccess] = useState("");

  useEffect(() => {
    fetchOrders();
  }, []);

  const fetchOrders = async () => {
    try {
      const res = await axios.get("/purchase/orders");
      setOrders(res.data);
    } catch (err) {
      setError("Errore nel recupero degli ordini.");
    } finally {
      setLoading(false);
    }
  };

  const openModal = (orderId, actionType) => {
    setSelectedOrderId(orderId);
    setSelectedAction(actionType);
    setNote("");
    setShowModal(true);
  };

  const handleRequestAction = async () => {
    try {
      await axios.put(`/purchase/request-action/${selectedOrderId}`, {
        action: selectedAction,
        note,
      });
      setShowModal(false);
      setSuccess("Richiesta inviata correttamente.");
      fetchOrders();
    } catch (err) {
      setError("Errore durante l'invio della richiesta.");
    }
  };

  if (loading) return <div className="container my-5">Caricamento ordini...</div>;

  return (
    <div className="container my-5">
      <h3>I miei Ordini</h3>
      {error && <div className="alert alert-danger">{error}</div>}
      {success && <div className="alert alert-success">{success}</div>}

      {orders.length === 0 ? (
        <p className="mt-3">Non hai ancora effettuato ordini.</p>
      ) : (
        <ul className="list-group mb-3">
          {orders.map((order, index) => (
            <li
              key={index}
              className="list-group-item d-flex justify-content-between align-items-center flex-column text-start"
            >
              <div className="w-100 mb-2 d-flex justify-content-between align-items-center">
                <div>
                  <strong>{order.productName}</strong> x{order.quantity}
                </div>
                <div>
                  {order.orderStatus === "Attivo" && !order.requestedAction && (
                    <>
                      <Button
                        variant="outline-danger"
                        size="sm"
                        className="me-2"
                        onClick={() => openModal(order.id, "Annullamento")}
                      >
                        Annulla
                      </Button>
                      <Button
                        variant="outline-secondary"
                        size="sm"
                        onClick={() => openModal(order.id, "Reso")}
                      >
                        Reso
                      </Button>
                    </>
                  )}
                  {order.orderStatus !== "Attivo" && (
                    <span className="badge bg-info text-dark">
                      {order.orderStatus}
                    </span>
                  )}
                  {order.requestedAction && order.orderStatus === "Attivo" && (
                    <span className="badge bg-warning text-dark">
                      Richiesta: {order.requestedAction}
                    </span>
                  )}
                </div>
              </div>
              <div className="w-100 d-flex justify-content-between">
                <span>Totale: {order.total.toFixed(2)} €</span>
                <span className="text-muted">Data: {order.date}</span>
              </div>
            </li>
          ))}
        </ul>
      )}

      {/* MODALE RICHIESTA */}
      <Modal show={showModal} onHide={() => setShowModal(false)}>
        <Modal.Header closeButton>
          <Modal.Title>Richiesta {selectedAction}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <Form.Group>
              <Form.Label>Motivo</Form.Label>
              <Form.Control
                as="textarea"
                rows={3}
                value={note}
                onChange={(e) => setNote(e.target.value)}
                placeholder="Spiega brevemente il motivo della richiesta"
              />
            </Form.Group>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => setShowModal(false)}>
            Annulla
          </Button>
          <Button variant="primary" onClick={handleRequestAction}>
            Invia richiesta
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
}

export default Orders;
