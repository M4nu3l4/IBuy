import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";

function Login() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError("");

    try {
      const response = await axios.post("https://localhost:7279/api/User/login", {
        email,
        password,
      });

      if (!response.data.token) {
        setError("Errore nella risposta del server: token mancante.");
        return;
      }

      localStorage.setItem(
        "user",
        JSON.stringify({
          token: response.data.token,
          email: response.data.email,
          username: response.data.user,
          roles: response.data.roles,
        })
      );

      window.dispatchEvent(new Event("storage"));

      navigate("/");
    } catch (err) {
      console.error(err);

      if (err.response) {
        if (err.response.status === 401) {
          setError("Email o password errati.");
        } else if (err.response.status === 500) {
          setError("Errore interno del server. Riprova più tardi.");
        } else if (typeof err.response.data === "string") {
          setError(err.response.data);
        } else {
          setError("Errore durante il login.");
        }
      } else {
        setError("Errore di rete: impossibile contattare il server.");
      }
    }
  };

  return (
    <div className="container my-5" style={{ maxWidth: "500px" }}>
      <h1 className="mb-3">Login</h1>
      {error && <div className="alert alert-danger">{error}</div>}

      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label>Email</label>
          <input
            type="email"
            className="form-control"
            required
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>

        <div className="mb-3">
          <label>Password</label>
          <input
            type="password"
            className="form-control"
            required
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>

        <button className="btn btn-dark w-100">Accedi</button>
      </form>
    </div>
  );
}

export default Login;
