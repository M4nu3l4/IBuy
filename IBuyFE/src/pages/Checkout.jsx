import React, { useState } from "react";
import { useCart } from "../contexts/CartContext";
import axios from "../utils/axiosConfig";
import { useNavigate } from "react-router-dom";
import { Modal, Button } from "react-bootstrap";
import { FaRegGrinStars } from "react-icons/fa";
import "bootstrap/dist/css/bootstrap.min.css";
import carteImg from "../assets/images/carte2.png"; 

function Checkout() {
  const { cartItems, clearCart, getTotalPrice } = useCart();
  const navigate = useNavigate();
  const [showModal, setShowModal] = useState(false);
  const [error, setError] = useState("");

  const handleCheckout = async () => {
    const userData = JSON.parse(localStorage.getItem("user"));
    const token = userData?.token;
  
    if (!token) {
      setError("Devi essere loggato per completare il pagamento.");
      navigate("/login");
      return;
    }
  
    const payload = cartItems.map((item) => ({
      productId: item.productId,
      productName: item.productName,
      price: item.price,
      quantity: item.quantity,
    }));
  
    console.log("Payload inviato:", payload);
  
    try {
      const response = await axios.post(
        "/purchase/checkout",
        payload,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );
      console.log("✅ Checkout riuscito:", response.data);
      setShowModal(true);
      clearCart();
      localStorage.removeItem("cart");
    } catch (err) {
      console.error("❌ Errore checkout:", err);
      setError("Impossibile completare il pagamento. Riprova più tardi.");
    }
  };
  

  const total = getTotalPrice();

 
  if ((!cartItems || cartItems.length === 0) && !showModal) {
    return (
      <div className="container my-5">
        <h4>Il carrello è vuoto.</h4>
        <Button variant="primary" onClick={() => navigate("/")}>
          Torna al catalogo
        </Button>
      </div>
    );
  }

  return (
    <div className="container my-5">
      <h3>Riepilogo ordine</h3>
      <ul className="list-group mb-3">
        {cartItems.map((item) => (
          <li
            key={item.productId}
            className="list-group-item d-flex justify-content-between align-items-center"
          >
            {item.productName} x{item.quantity}
            <span>{(item.price * item.quantity).toFixed(2)} €</span>
          </li>
        ))}
      </ul>
      <h4>Totale: {total.toFixed(2)} €</h4>

      {error && <div className="alert alert-danger mt-3">{error}</div>}

      <button className="btn btn-success mt-3" onClick={handleCheckout}>
        Conferma e paga
      </button>

      <div className="mt-3">
        <Button variant="secondary" onClick={() => navigate("/cart")}>
          Torna al carrello
        </Button>

  
        <div className="text-center mt-4">
          <img
            src={carteImg}
            alt="Metodi di pagamento"
            className="img-fluid"
            style={{ maxWidth: "300px" }}
          />
        </div>
      </div>

      <Modal
        show={showModal}
        onHide={() => {
          setShowModal(false);
          navigate("/");
        }}
        centered
      >
        <Modal.Header closeButton>
          <Modal.Title>Pagamento completato!</Modal.Title>
        </Modal.Header>
        <Modal.Body className="text-center">
          <FaRegGrinStars size={64} className="text-success mb-3" />
          <p>Grazie per il tuo ordine! 🎉</p>
          <p>Riceverai una mail di conferma.</p>
        </Modal.Body>
        <Modal.Footer>
          <Button
            variant="success"
            onClick={() => {
              setShowModal(false);
              navigate("/");
            }}
          >
            Torna alla home
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
}

export default Checkout;
