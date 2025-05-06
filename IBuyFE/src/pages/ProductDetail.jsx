import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";
import { useCart } from "../contexts/CartContext";
import { Navigate } from "react-router-dom";

function ProductDetail() {
  const { id } = useParams();
  const [product, setProduct] = useState(null);
  const { addToCart } = useCart();
  const navigate = useNavigate();

  useEffect(() => {
    const fetchProduct = async () => {
      try {
        const res = await axios.get(`https://localhost:7279/api/Product/${id}`);
        setProduct(res.data);
      } catch (err) {
        console.error("Errore nel caricamento del prodotto:", err);
      }
    };

    fetchProduct();
  }, [id]);

  if (!product) return <div className="container my-4">Caricamento...</div>;

  return (
    <div className="product-detail-container" key={product.id}>
   
    
      <img
        src={`https://localhost:7279/${product.image?.replace(/^\/+/, "")}`}
        className="card-img-top"
        alt={product.name}
        style={{ objectFit: "contain", height: "200px" }}
      />
      <div className="card-body d-flex flex-column">
        <h5 className="card-title">{product.name}</h5>
        <p className="card-text">{product.description}</p>
        <p className="card-text fw-bold mb-2">€ {product.price}</p>
        <div className="mt-auto d-grid gap-2">    
          <button
            className="btn btn-outline-success"
            onClick={() => addToCart(product)}
          >
            Aggiungi al carrello
          </button>
          <button className="btn btn-outline-secondary" onClick={() => navigate("/")}>
          Torna alla Home
        </button>
        </div>
      </div>
   
  </div>
  );
}

export default ProductDetail;
