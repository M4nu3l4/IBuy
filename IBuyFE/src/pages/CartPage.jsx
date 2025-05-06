import React from "react";
import { useNavigate } from "react-router-dom";
import { useCart } from "../contexts/CartContext";

function CartPage() {
  const { cartItems, removeFromCart, getTotalPrice } = useCart();
  const navigate = useNavigate();

  return (
    <div className="container mt-5">
      <h2>Il tuo carrello</h2>
      {cartItems.length === 0 ? (
        <p>Il carrello è vuoto.</p>
      ) : (
        <>
          <table className="table">
            <tbody>
              {cartItems.map((item) => (
                <tr key={item.productId}>
                  <td>x {item.quantity}</td>
                  <td>{item.productName}</td>
                  <td>€ {item.price.toFixed(2)}</td>
                  <td>
                    <button
                      className="btn btn-danger btn-sm"
                      onClick={() => removeFromCart(item.productId)}
                    >
                      Rimuovi
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <h4 className="mt-4">
            Totale: € {getTotalPrice().toFixed(2)}
          </h4>
          <button
            className="btn btn-primary mt-3"
            onClick={() => navigate("/checkout")}
          >
            Vai al pagamento
          </button>
        </>
      )}
    </div>
  );
}

export default CartPage;

