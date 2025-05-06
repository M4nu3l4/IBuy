import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";

function Register() {
  const [form, setForm] = useState({
    userName: "",
    email: "",
    password: "",
    role: "Cliente",
  });

 
  const [extra, setExtra] = useState({
    address: "",
    city: "",
    cap: "",
    phone: "",
    discountCode: ""
  });
 

  const [error, setError] = useState("");
  const [success, setSuccess] = useState("");
  const navigate = useNavigate();

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleExtraChange = (e) => {
    setExtra({ ...extra, [e.target.name]: e.target.value });
  };
 

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError("");
    setSuccess("");

    try {
     
      await axios.post("https://localhost:7279/api/User/register", form);

     
      localStorage.setItem("pendingUserExtra", JSON.stringify(extra));

      setSuccess("Registrazione completata con successo!");
      setTimeout(() => navigate("/login"), 2000);
    } catch (err) {
      console.error(err);
      setError("Errore durante la registrazione.");
    }
  };

  return (
    <div className="container my-5" style={{ maxWidth: "600px" }}>
      <h1 className="mb-3 text-center ">Registrati</h1>
      {success && <div className="alert alert-success">{success}</div>}
      {error && <div className="alert alert-danger">{error}</div>}

      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label>Nome utente</label>
          <input
            name="userName"
            className="form-control"
            required
            value={form.userName}
            onChange={handleChange}
          />
        </div>

        <div className="mb-3">
          <label>Email</label>
          <input
            name="email"
            type="email"
            className="form-control"
            required
            value={form.email}
            onChange={handleChange}
          />
        </div>

        <div className="mb-3">
          <label>Password</label>
          <input
            name="password"
            type="password"
            className="form-control"
            required
            value={form.password}
            onChange={handleChange}
          />
        </div>

        <div className="mb-3">
          <label>Indirizzo di spedizione</label>
          <input
            name="address"
            className="form-control"
            placeholder="via numero civico"
            value={extra.address}
            onChange={handleExtraChange}
          />
        </div>
        <div className="mb-3">
          <label>Città</label>
          <input
            name="city"
            className="form-control"
            value={extra.city}
            onChange={handleExtraChange}
          />
        </div>
        <div className="mb-3">
          <label>CAP</label>
          <input
            name="cap"
            className="form-control"
            value={extra.cap}
            onChange={handleExtraChange}
          />
        </div>
        <div className="mb-3">
          <label>Telefono</label>
          <input
            name="phone"
            className="form-control"
            value={extra.phone}
            onChange={handleExtraChange}
          />
        </div>
        <div className="mb-3">
          <label>Codice sconto (opzionale)</label>
          <input
            name="discountCode"
            className="form-control"
            placeholder="Se hai un codice promozionale"
            value={extra.discountCode}
            onChange={handleExtraChange}
          />
        </div>
    

        <button className="btn btn-success w-100">Registrati</button>
      </form>
    </div>
  );
}

export default Register;
