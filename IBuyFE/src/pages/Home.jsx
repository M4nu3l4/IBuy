import { useEffect, useState } from "react";
import axios from "axios";
import { Link } from "react-router-dom";
import { useCart } from "../contexts/CartContext";

import { useWishlist } from "../contexts/WishlistContext";

import {
  FaLaptop,
  FaTshirt,
  FaDog,
  FaRunning,
  FaCouch,
  FaSpa,
  FaStar,
} from "react-icons/fa";
import { motion } from "framer-motion";
import { BsHeart, BsHeartFill } from "react-icons/bs";
import AlertDismissible from "../pages/Sconto"; 


const Home = () => {
  const [products, setProducts] = useState([]);
  const [allProducts, setAllProducts] = useState([]);
  const [error, setError] = useState("");
  const [searchTerm, setSearchTerm] = useState("");
  const [activeCategory, setActiveCategory] = useState("");
  const [wishlist, setWishlist] = useState([]);
  const [user, setUser] = useState(null);

  const { addToCart } = useCart();

  const staticCategories = [
    { label: "Tecnologia", value: "Tecnologia" },
    { label: "Cura della persona", value: "Cosmetici" },
    { label: "Elettrodomestici", value: "Elettrodomestici" },
    { label: "Abbigliamento", value: "Abbigliamento" },
    { label: "Tempo libero", value: "Tempo libero" },
    { label: "Attrezzatura sportiva", value: "Attrezzatura sportiva" },
    { label: "Amici animali", value: "Amici animali" },
  ];

  const categoryIcons = {
    "Tecnologia": <FaLaptop className="me-2" />,
    "Cura della persona": <FaSpa className="me-2" />,
    "Elettrodomestici": <FaCouch className="me-2" />,
    "Abbigliamento": <FaTshirt className="me-2" />,
    "Tempo libero": <FaStar className="me-2" />,
    "Attrezzatura sportiva": <FaRunning className="me-2" />,
    "Amici animali": <FaDog className="me-2" />,
  };

  useEffect(() => {
    fetchAllProducts();

    const savedWishlist = JSON.parse(localStorage.getItem("wishlist")) || [];
    setWishlist(savedWishlist);

    const savedUser = JSON.parse(localStorage.getItem("user"));
    setUser(savedUser);
  }, []);

  useEffect(() => {
    localStorage.setItem("wishlist", JSON.stringify(wishlist));
  }, [wishlist]);

  const fetchAllProducts = async () => {
    try {
      const res = await axios.get("https://localhost:7279/api/Product");
      setProducts(res.data);
      setAllProducts(res.data);
      setError("");
    } catch (err) {
      setError("Errore nel caricamento dei prodotti.");
    }
  };

  const handleCategoryClick = async (category) => {
    setSearchTerm("");
    setActiveCategory(category);

    if (category === "") {
      setProducts(allProducts);
      setError("");
      return;
    }

    try {
      const res = await axios.get(
        `https://localhost:7279/api/Product/category/${encodeURIComponent(category)}`
      );
      setProducts(res.data);
      setError("");
    } catch (err) {
      setProducts([]);
      setError("Nessun prodotto trovato per la categoria selezionata.");
    }
  };

  const toggleWishlist = (productId) => {
    if (wishlist.includes(productId)) {
      setWishlist(wishlist.filter((id) => id !== productId));
    } else {
      setWishlist([...wishlist, productId]);
    }
  };

  const isWishlisted = (productId) => wishlist.includes(productId);

  const filtered = products.filter((p) =>
    p.name.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="container mt-4">
       <AlertDismissible />
      <h1 className="text-center mb-4">Catalogo Prodotti</h1>

      <div className="row mb-4">
        <div className="col-md-12">
          <input
            type="text"
            placeholder="Cerca per nome..."
            className="form-control rounded-pill shadow-sm"
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
        </div>
      </div>

      <div className="mb-4 overflow-auto d-flex gap-3 p-3  rounded shadow-sm">
        <button
          className={`btn rounded-pill px-3 fw-bold ${
            activeCategory === "" ? "btn-light" : "btn btn-outline-dark"
          }`}
          onClick={() => handleCategoryClick("")}
        >
          Tutte
        </button>
        {staticCategories.map((cat, idx) => (
          <button
            key={idx}
            className={`btn px-3 py-2 fw-semibold border rounded-pill text-nowrap ${
              activeCategory === cat.value ? "btn-light" : "btn-outline-light"
            }`}
            onClick={() => handleCategoryClick(cat.value)}
          >
            {categoryIcons[cat.label]} {cat.label}
          </button>
        ))}
      </div>

      {error && <div className="alert alert-danger">{error}</div>}

      {filtered.length > 0 ? (
        <div className="row">
          {filtered.slice(0, 21).map((product, idx) => (
            <div className="col-md-4 mb-4" key={product.id}>
              <motion.div
                className="card h-100 shadow-sm"
                initial={{ opacity: 0, y: 50 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ duration: 0.5, delay: idx * 0.1 }}
                whileHover={{
                  scale: 1.04,
                  boxShadow: "0 8px 24px rgba(63,94,251,0.14), 0 1.5px 6px rgba(0,0,0,0.10)",
                  y: -8,
                  transition: { type: "spring", stiffness: 350, damping: 20 }
                }}
              >
                <img
                  src={`https://localhost:7279/${product.image?.replace(/^\/+/, "")}`}
                  className="card-img-top"
                  alt={product.name}
                  style={{ objectFit: "contain", height: "200px" }}
                />
                <div className="card-body d-flex flex-column">
                  <h5 className="card-title">{product.name}</h5>
                  <p className="card-text">{product.description}</p>
                  <p className="card-text fw-bold">€ {product.price}</p>

                  {user && (
                    <div className="d-flex justify-content-end mb-2">
                      <button
                        className="btn btn-sm"
                        onClick={() => toggleWishlist(product.id)}
                        aria-label="Aggiungi ai preferiti"
                      >
                        {isWishlisted(product.id) ? (
                          <BsHeartFill className="text-danger" size={20} />
                        ) : (
                          <BsHeart className="text-secondary" size={20} />
                        )}
                      </button>
                    </div>
                  )}

                  <div className="mt-auto d-grid gap-2">
                    <Link to={`/prodotti/${product.id}`} className="btn btn-secondary">
                      Dettagli
                    </Link>
                    <button
                      className="btn btn-outline-secondary"
                      onClick={() => addToCart(product)}
                    >
                      Aggiungi al carrello
                    </button>
                  </div>
                </div>
              </motion.div>
            </div>
          ))}
        </div>
      ) : (
        <div className="alert alert-warning">Nessun prodotto trovato.</div>
      )}
    </div>
  );
};

export default Home;
