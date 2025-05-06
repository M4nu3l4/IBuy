import React, { useEffect, useState } from "react";
import axios from "axios";

function MyInfo() {
  const [user, setUser] = useState(null);
  const [details, setDetails] = useState({
    address: "",
    city: "",
    cap: "",
    phone: "",
    discountCode: "",
    creditCard: "",
    iban: ""
  });
  const [editing, setEditing] = useState(false);
  const [success, setSuccess] = useState("");
  const [error, setError] = useState("");

  useEffect(() => {
    const userData = JSON.parse(localStorage.getItem("user"));
    setUser(userData);

    if (userData && userData.token) {
      axios
        .get("https://localhost:7279/api/User/customer-details", {
          headers: { Authorization: `Bearer ${userData.token}` }
        })
        .then(res => {
          if (res.data) setDetails(res.data);
        })
        .catch(() => setError("Errore nel caricamento dei dettagli"));
    }
  }, []);

  const handleChange = (e) => {
    setDetails({ ...details, [e.target.name]: e.target.value });
  };

  const handleSave = async (e) => {
    e.preventDefault();
    setSuccess("");
    setError("");
    try {
      await axios.post(
        "https://localhost:7279/api/User/customer-details",
        {
          ...details,
          email: user.email
        },
        {
          headers: { Authorization: `Bearer ${user.token}` }
        }
      );
      setSuccess("Dati aggiornati con successo!");
      setEditing(false);
    } catch {
      setError("Errore durante il salvataggio.");
    }
  };

  if (!user)
    return <div className="container my-5">Effettua il login per vedere i tuoi dati.</div>;

  return (
    <div className="container my-5 d-flex flex-column align-items-center">
      <div className="p-4 bg-white rounded shadow" style={{ minWidth: 350, maxWidth: 480 }}>
        <div className="mb-3 fw-bold text-primary">Ciao, {user.username || user.user || "Utente"}</div>
        <h1 className="mb-3">Informazioni Utente</h1>
        <div><b>Username:</b> {user.user}</div>
        <div><b>Email:</b> {user.email}</div>
        <div><b>Ruolo:</b> {user.roles && user.roles[0]}</div>
        <hr />

        {!editing ? (
          <div>
            <div><b>Indirizzo:</b> {details.address}</div>
            <div><b>Città:</b> {details.city}</div>
            <div><b>CAP:</b> {details.cap}</div>
            <div><b>Telefono:</b> {details.phone}</div>
            <div><b>Codice Sconto:</b> {details.discountCode}</div>
            <div><b>Carta di Credito:</b> {details.creditCard}</div>
            <div><b>IBAN:</b> {details.iban}</div>
            <button
              className="btn btn-link text-primary mt-3"
              onClick={() => setEditing(true)}
              title="Modifica dati"
              style={{ textDecoration: "none", fontSize: 20 }}
            >
              <span role="img" aria-label="Modifica">✏️</span> Modifica
            </button>
            {success && <div className="alert alert-success my-2">{success}</div>}
            {error && <div className="alert alert-danger my-2">{error}</div>}
          </div>
        ) : (
          <form onSubmit={handleSave}>
            <div className="mb-2">
              <label>Indirizzo</label>
              <input name="address" className="form-control" value={details.address || ""} onChange={handleChange} />
            </div>
            <div className="mb-2">
              <label>Città</label>
              <input name="city" className="form-control" value={details.city || ""} onChange={handleChange} />
            </div>
            <div className="mb-2">
              <label>CAP</label>
              <input name="cap" className="form-control" value={details.cap || ""} onChange={handleChange} />
            </div>
            <div className="mb-2">
              <label>Telefono</label>
              <input name="phone" className="form-control" value={details.phone || ""} onChange={handleChange} />
            </div>
            <div className="mb-2">
              <label>Codice Sconto</label>
              <input name="discountCode" className="form-control" value={details.discountCode || ""} onChange={handleChange} />
            </div>
            <div className="mb-2">
              <label>Carta di Credito</label>
              <input name="creditCard" className="form-control" value={details.creditCard || ""} onChange={handleChange} maxLength={25} placeholder="Solo ultimi 4 cifre visibili in card" />
            </div>
            <div className="mb-2">
              <label>IBAN</label>
              <input name="iban" className="form-control" value={details.iban || ""} onChange={handleChange} maxLength={34} />
            </div>
            {success && <div className="alert alert-success my-2">{success}</div>}
            {error && <div className="alert alert-danger my-2">{error}</div>}
            <div className="d-flex justify-content-between mt-3">
              <button type="button" className="btn btn-secondary" onClick={() => setEditing(false)}>Annulla</button>
              <button type="submit" className="btn btn-primary">Salva</button>
            </div>
          </form>
        )}
      </div>
    </div>
  );
}

export default MyInfo;
