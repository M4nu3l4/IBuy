import React, { useState, useEffect, useRef } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useCart } from "../contexts/CartContext";
import "bootstrap-icons/font/bootstrap-icons.css";
import "bootstrap/dist/css/bootstrap.min.css";
import LogoIbuy from "../assets/images/20250423_1554_Scrittaremix_01jsheswbnfvr9wt0mznrd84nd.png";

function Navbar() {
  const { cartItems } = useCart();
  const [user, setUser] = useState(null);
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();
  const dropdownRef = useRef(null);

  const getUserRole = (userObj) => {
    if (!userObj) return null;
    if (userObj.roles && userObj.roles.length) return userObj.roles[0];
    if (userObj.role) return userObj.role;
    return null;
  };

  useEffect(() => {
    const data = localStorage.getItem("user");
    if (data) setUser(JSON.parse(data));
    setLoading(false);
  }, []);

  useEffect(() => {
    const syncUser = () => {
      const data = localStorage.getItem("user");
      setUser(data ? JSON.parse(data) : null);
    };
    window.addEventListener("storage", syncUser);
    return () => window.removeEventListener("storage", syncUser);
  }, []);

  useEffect(() => {
    const handleClickOutside = (event) => {
      if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
        setDropdownOpen(false);
      }
    };
    document.addEventListener("mousedown", handleClickOutside);
    return () => document.removeEventListener("mousedown", handleClickOutside);
  }, []);

  const handleLogout = () => {
    localStorage.removeItem("user");
    setUser(null);
    window.dispatchEvent(new Event("storage"));
    navigate("/login");
  };

  const totalItems = cartItems.reduce((sum, item) => sum + item.quantity, 0);
  const ruolo = getUserRole(user);

  return (
    <nav className="navbar navbar-dark bg-black px-4 py-2 d-flex justify-content-between align-items-center">
      <Link to="/" className="navbar-brand d-flex align-items-center text-white fs-4">
        <img
          src={LogoIbuy}
          alt="Logo IBuy"
          style={{ height: "40px", width: "110px ", marginRight: "30px", borderRadius: "15px" }}
        />
      </Link>

      {!loading && (
        <div className="d-flex align-items-center position-relative">
          {user ? (
            <>
              <span className="text-white me-2">Ciao {user.username || user.user || "Utente"}</span>
              <div className="position-relative me-3" ref={dropdownRef}>
                <button
                  className="btn btn-outline-light rounded-circle"
                  onClick={() => setDropdownOpen(!dropdownOpen)}
                >
                  <i className="bi bi-person-circle"></i>
                </button>
                {dropdownOpen && (
                  <div className="position-absolute end-0 mt-2 bg-white rounded shadow-sm z-3">
                    <ul className="list-unstyled m-0 p-2">
                      <li>
                        <Link className="dropdown-item" to="/my-info" onClick={() => setDropdownOpen(false)}>
                          My Info
                        </Link>
                      </li>

                      {ruolo === "AdminOffice" && (
                        <>
                          <li>
                            <Link className="dropdown-item" to="/dashboard-admin-office" onClick={() => setDropdownOpen(false)}>
                              Dashboard Guadagni
                            </Link>
                          </li>
                          <li>
                            <Link className="dropdown-item" to="/admin-orders" onClick={() => setDropdownOpen(false)}>
                              Lista Ordini
                            </Link>
                          </li>
                        </>
                      )}

                      {(ruolo === "AdminFe" || ruolo === "AdminBe") && (
                        <li>
                          <Link className="dropdown-item" to="/gestione-prodotti" onClick={() => setDropdownOpen(false)}>
                            Gestione Prodotti
                          </Link>
                        </li>
                      )}

                      {ruolo === "Cliente" && (
                        <>
                          <li>
                            <Link className="dropdown-item" to="/wishlist" onClick={() => setDropdownOpen(false)}>
                              Lista desideri
                            </Link>
                          </li>
                          <li>
                            <Link className="dropdown-item" to="/orders" onClick={() => setDropdownOpen(false)}>
                              I miei ordini
                            </Link>
                          </li>
                          <li>
                            <Link className="dropdown-item" to="/contact-us" onClick={() => setDropdownOpen(false)}>
                              Contattaci
                            </Link>
                          </li>
                        </>
                      )}

                      <li><hr className="dropdown-divider" /></li>
                      <li>
                        <button className="dropdown-item text-danger" onClick={handleLogout}>
                          Logout
                        </button>
                      </li>
                    </ul>
                  </div>
                )}
              </div>
            </>
          ) : (
            <>
              <Link to="/register" className="btn btn-outline-light me-2">Registrati</Link>
              <Link to="/login" className="btn btn-outline-light me-2">Login</Link>
            </>
          )}

          <Link to="/cart" className="btn btn-outline-light position-relative">
            <i className="bi bi-cart3"></i>
            {totalItems > 0 && (
              <span className="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger">
                {totalItems}
              </span>
            )}
          </Link>
        </div>
      )}
    </nav>
  );
}

export default Navbar;
