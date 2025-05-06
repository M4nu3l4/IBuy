// src/pages/Wishlist.jsx
import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { BsHeartFill } from "react-icons/bs";

const Wishlist = () => {
  const [wishlist, setWishlist] = useState([]);
  const [products, setProducts] = useState([]);

  useEffect(() => {
    
    const savedWishlist = JSON.parse(localStorage.getItem("wishlist")) || [];
    setWishlist(savedWishlist);
    
    fetchProducts(savedWishlist);
  }, []);

  const fetchProducts = async (wishlistIds) => {
    try {
      const res = await fetch("https://localhost:7279/api/Product");
      const data = await res.json();
    
      const filtered = data.filter((p) => wishlistIds.includes(p.id));
      setProducts(filtered);
    } catch (err) {
      setProducts([]);
    }
  };

  const removeFromWishlist = (productId) => {
    const updatedWishlist = wishlist.filter((id) => id !== productId);
    setWishlist(updatedWishlist);
    localStorage.setItem("wishlist", JSON.stringify(updatedWishlist));
    setProducts(products.filter((p) => p.id !== productId));
  };

  return (
    <div className="container mt-5">
      <h1 className="mb-4">La tua Lista dei Desideri</h1>
      {products.length === 0 ? (
        <div className="alert alert-info">La tua wishlist è vuota.</div>
      ) : (
        <div className="row">
          {products.map((item) => (
            <div className="col-md-4 mb-4" key={item.id}>
              <div className="card h-100 shadow-sm position-relative">
                <img
                  src={`https://localhost:7279/${item.image?.replace(/^\/+/, "")}`}
                  className="card-img-top"
                  alt={item.name}
                  style={{ objectFit: "contain", height: "200px" }}
                />
                <div className="card-body d-flex flex-column">
                  <h5 className="card-title">{item.name}</h5>
                  <p className="card-text">{item.description}</p>
                  <p className="fw-bold">€ {item.price}</p>

                  <div className="mt-auto d-flex justify-content-between">
                    <Link
                      to={`/prodotti/${item.id}`}
                      className="btn btn-primary"
                    >
                      Dettagli
                    </Link>
                    <button
                      className="btn btn-outline-danger"
                      onClick={() => removeFromWishlist(item.id)}
                    >
                      <BsHeartFill className="me-1" />
                      Rimuovi
                    </button>
                  </div>
                </div>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default Wishlist;
