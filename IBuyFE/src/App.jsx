import React, { useEffect, useState } from "react";
import { Routes, Route, Outlet } from "react-router-dom";
import Navbar from "./components/Navbar";
import Footer from "./components/footer";
import Home from "./pages/Home";
import Cart from "./pages/CartPage";
import Login from "./pages/Login";
import Register from "./pages/Register";
import ProductDetail from "./pages/ProductDetail";
import Checkout from "./pages/Checkout";
import Wishlist from "./pages/Wishlist";
import Orders from "./pages/Orders";
import MyInfo from "./pages/MyInfo";
import ContactUs from "./pages/ContactUs";
import AdminUsers from "./pages/AdminUsers";
import AccessDenied from "./pages/AccessDenied";
import Privacy from "./pages/Privacy";
import LavoraConNoi from "./pages/LavoraConNoi";
import Sconto from "./pages/Sconto";
import DashboardAdminOffice from "./pages/DashboardAdminOffice";
import GestioneProdotti from "./pages/GestioneProdotti";
import AdminOrders from "./pages/AdminOrders";
import ImageCarousel from "./components/ImageCarousel";

function App() {
  const [user, setUser] = useState(null);
  const [loadingUser, setLoadingUser] = useState(true);

  useEffect(() => {
    try {
      const data = localStorage.getItem("user");
      if (data) {
        setUser(JSON.parse(data));
      }
    } catch {
      setUser(null);
    } finally {
      setLoadingUser(false);
    }
  }, []);

  if (loadingUser) {
    return <div className="container my-5">Caricamento utente...</div>;
  }

  return (
    <>
      <Navbar />
      <Routes>
        <Route path="/" element={<Outlet />}>
          <Route index element={<Home />} />
          <Route path="cart" element={<Cart />} />
          <Route path="login" element={<Login />} />
          <Route path="register" element={<Register />} />
          <Route path="wishlist" element={<Wishlist />} />
          <Route path="orders" element={<Orders />} />
          <Route path="my-info" element={<MyInfo />} />
          <Route path="prodotti/:id" element={<ProductDetail />} />
          <Route path="checkout" element={<Checkout />} />
          <Route path="contact-us" element={<ContactUs />} />
          <Route path="privacy" element={<Privacy />} />
          <Route path="lavora-con-noi" element={<LavoraConNoi />} />
          <Route path="sconto" element={<Sconto />} />
          <Route path="access-denied" element={<AccessDenied />} />
          <Route path="/dashboard-admin-office" element={<DashboardAdminOffice />} />
          <Route
            path="/admin"
            element={
              user?.roles?.includes("AdminOffice") ? (
                <AdminUsers />
              ) : (
                <AccessDenied />
              )
            }
          />
          <Route
            path="/gestione-prodotti"
            element={
              user?.roles?.some((r) => ["AdminFe", "AdminBe"].includes(r)) ? (
                <GestioneProdotti />
              ) : (
                <AccessDenied />
              )
            }
          />
          <Route
            path="/admin-orders"
            element={
              user?.roles?.includes("AdminOffice") ? (
                <AdminOrders />
              ) : (
                <AccessDenied />
              )
            }
          />

          <Route path="*" element={<div>404 Not Found</div>} />
        </Route>
      </Routes>
      <ImageCarousel />
      <Footer />
    </>
  );
}

export default App;
