import React from "react";
import { useNavigate } from "react-router-dom";
import { useCart } from "../contexts/CartContext";

function Cart() {
  const { cartItems, removeFromCart, getTotalPrice } = useCart();
  const navigate = useNavigate();
  const user = JSON.parse(localStorage.getItem("user"));

  if (!user) {
    return (
      <div className="container my-4">
        <div className="alert alert-warning text-center">
          Effettua il login per accedere al carrello.
        </div>
      </div>
    );
  }

  if (cartItems.length === 0) {
    return (
      <div className="container my-4">
        <div className="alert alert-info text-center">
          Il carrello è vuoto.
        </div>
      </div>
    );
  }

  const total = getTotalPrice();

  return (
    <div className="container my-4">
      <h2>Il tuo carrello</h2>
      <ul className="list-group mb-3">
        {cartItems.map((item) => (
          <li
            key={item.productId}
            className="list-group-item d-flex justify-content-between align-items-center"
          >
            <div>
              <strong>{item.productName}</strong> x {item.quantity}
            </div>
            <div>
              {(item.price * item.quantity).toFixed(2)} €
              <button
                className="btn btn-sm btn-danger ms-3"
                onClick={() => removeFromCart(item.productId)}
              >
                🗑
              </button>
            </div>
          </li>
        ))}
      </ul>

      <h5 className="text-end">Totale: € {total.toFixed(2)}</h5>

      <div className="text-end">
        <button
          className="btn btn-primary"
          onClick={() => navigate("/checkout")}
        >
          Vai al pagamento
        </button>
      </div>
    </div>
  );
}

export default Cart;
