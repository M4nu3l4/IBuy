import React, { useEffect, useState } from "react";
import axios from "axios";

const LOGO_PLACEHOLDER = "https://localhost:7279/images/20250423_1554_Scrittaremix_01jsheswbnfvr9wt0mznrd84nd.png";

function GestioneProdotti() {
  const [prodotti, setProdotti] = useState([]);
  const [categorie, setCategorie] = useState([]);
  const [editing, setEditing] = useState(null);
  const [form, setForm] = useState({
    name: "",
    description: "",
    price: "",
    quantity: "",
    producer: "",
    image: "",
    categoryId: "",
    isBestSeller: false,
  });
  const [user] = useState(() => JSON.parse(localStorage.getItem("user")));
  const [error, setError] = useState("");
  const [success, setSuccess] = useState("");

  useEffect(() => {
    if (
      user &&
      user.token &&
      user.roles &&
      (user.roles.includes("AdminFe") || user.roles.includes("AdminBe"))
    ) {
      caricaProdotti(user.token);
      caricaCategorie(user.token);
    }
  }, [user]);

  const caricaProdotti = (token) => {
    axios
      .get("https://localhost:7279/api/Product", {
        headers: { Authorization: `Bearer ${token}` },
      })
      .then((res) => setProdotti(res.data))
      .catch(() => setError("Errore nel caricamento prodotti"));
  };

  const caricaCategorie = (token) => {
    axios
      .get("https://localhost:7279/api/Category", {
        headers: { Authorization: `Bearer ${token}` },
      })
      .then((res) => setCategorie(res.data))
      .catch(() => setCategorie([]));
  };

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setForm((f) => ({
      ...f,
      [name]: type === "checkbox" ? checked : value,
    }));
  };

  const handleEdit = (prodotto) => {
    setEditing(prodotto.id);
    setForm({
      name: prodotto.name ?? "",
      description: prodotto.description ?? "",
      price: prodotto.price ?? "",
      quantity: prodotto.quantity ?? "",
      producer: prodotto.producer ?? "",
      image: prodotto.image ?? "",
      categoryId: prodotto.categoryId ?? "",
      isBestSeller: prodotto.isBestSeller ?? false,
    });
    setSuccess("");
    setError("");
  };

  const handleSave = async (e) => {
    e.preventDefault();
    setSuccess("");
    setError("");
    if (!user || !user.token) {
      setError("Non autenticato!");
      return;
    }
    if (!form.name || !form.price || !form.quantity || !form.categoryId || !form.producer) {
      setError("Tutti i campi obbligatori vanno compilati.");
      return;
    }
    const payload = {
      name: form.name,
      description: form.description,
      price: parseFloat(form.price),
      quantity: parseInt(form.quantity, 10),
      producer: form.producer,
      image: form.image,
      categoryId: form.categoryId,
      isBestSeller: !!form.isBestSeller,
    };
    try {
      if (editing) {
        await axios.put(
          `https://localhost:7279/api/Product/${editing}`,
          payload,
          { headers: { Authorization: `Bearer ${user.token}` } }
        );
        setSuccess("Prodotto aggiornato!");
      } else {
        await axios.post(
          "https://localhost:7279/api/Product",
          payload,
          { headers: { Authorization: `Bearer ${user.token}` } }
        );
        setSuccess("Prodotto aggiunto!");
      }
      setForm({
        name: "",
        description: "",
        price: "",
        quantity: "",
        producer: "",
        image: "",
        categoryId: "",
        isBestSeller: false,
      });
      setEditing(null);
      caricaProdotti(user.token);
    } catch (err) {
      setError("Errore durante il salvataggio.");
    }
  };

  const handleDelete = async (id) => {
    if (!user || !user.token) return;
    if (!window.confirm("Sei sicuro di voler eliminare questo prodotto?")) return;
    try {
      await axios.delete(`https://localhost:7279/api/Product/${id}`, {
        headers: { Authorization: `Bearer ${user.token}` },
      });
      setSuccess("Prodotto eliminato!");
      caricaProdotti(user.token);
    } catch {
      setError("Errore durante l'eliminazione.");
    }
  };

  const handleCancel = () => {
    setEditing(null);
    setForm({
      name: "",
      description: "",
      price: "",
      quantity: "",
      producer: "",
      image: "",
      categoryId: "",
      isBestSeller: false,
    });
    setError("");
    setSuccess("");
  };

  if (user === null) {
    return <div className="container my-5 text-center">Caricamento...</div>;
  }

  if (
    !user.token ||
    !user.roles ||
    (!user.roles.includes("AdminFe") && !user.roles.includes("AdminBe"))
  ) {
    return (
      <div className="container my-5">
        <div className="alert alert-danger">
          Non autorizzato. Solo AdminFe o AdminBe possono accedere a questa pagina.
        </div>
      </div>
    );
  }

  const getImageUrl = (img) => {
    if (!img) return LOGO_PLACEHOLDER;
    if (img.startsWith("http")) return img;
    return `https://localhost:7279/${img.replace(/^\/+/, "")}`;
  };

  return (
    <div className="container my-5">
      <h1 className="text-center">Gestione Prodotti</h1>
      <p>Solo AdminFe e AdminBe possono accedere.</p>
      {error && <div className="alert alert-danger my-2">{error}</div>}
      {success && <div className="alert alert-success my-2">{success}</div>}

      <div className="card p-3 mb-4">
        <h5 className="text-center">{editing ? "Modifica Prodotto" : "Aggiungi Prodotto"}</h5>
        <div className="text-center mb-3">
          <img
            src={getImageUrl(form.image)}
            alt={form.name || "Anteprima prodotto"}
            style={{ maxHeight: 90, maxWidth: 200, objectFit: "contain", borderRadius: 8, boxShadow: "0 0 5px #bbb", background: "#f6f6f6" }}
            onError={e => {
              if (e.target.src !== LOGO_PLACEHOLDER) {
                e.target.onerror = null;
                e.target.src = LOGO_PLACEHOLDER;
              }
            }}
          />
        </div>

        <form onSubmit={handleSave}>
          <div className="row">
            <div className="col">
              <input name="name" className="form-control mb-2" placeholder="Nome" value={form.name} onChange={handleChange} required />
            </div>
            <div className="col">
              <select name="categoryId" className="form-control mb-2" value={form.categoryId} onChange={handleChange} required>
                <option value="">Seleziona Categoria</option>
                {categorie.map((cat) => (
                  <option key={cat.id} value={cat.id}>{cat.name}</option>
                ))}
              </select>
            </div>
          </div>

          <input name="producer" className="form-control mb-2" placeholder="Produttore" value={form.producer} onChange={handleChange} required />

          <textarea name="description" className="form-control mb-2" placeholder="Descrizione" value={form.description} onChange={handleChange} rows={2} />

          <div className="row">
            <div className="col">
              <input name="price" type="number" min="0" step="0.01" className="form-control mb-2" placeholder="Prezzo" value={form.price} onChange={handleChange} required />
            </div>
            <div className="col">
              <input name="quantity" type="number" min="0" className="form-control mb-2" placeholder="Quantità" value={form.quantity} onChange={handleChange} required />
            </div>
            <div className="col">
              <input name="image" className="form-control mb-2" placeholder="Percorso immagine (es: images/prodotto.jpg)" value={form.image} onChange={handleChange} />
            </div>
          </div>

          <div className="form-check mb-2">
            <input className="form-check-input" type="checkbox" name="isBestSeller" checked={form.isBestSeller} onChange={handleChange} id="isBestSeller" />
            <label className="form-check-label" htmlFor="isBestSeller">Bestseller</label>
          </div>

          <div>
            <button className="btn btn-success me-2" type="submit">{editing ? "Salva modifiche" : "Aggiungi"}</button>
            {editing && (
              <button className="btn btn-secondary" type="button" onClick={handleCancel}>Annulla</button>
            )}
          </div>
        </form>
      </div>

      <div className="card p-3">
        <h5>Elenco Prodotti</h5>
        <div className="table-responsive">
          <table className="table table-hover table-striped">
            <thead>
              <tr>
                <th>Nome</th>
                <th>Categoria</th>
                <th>Prezzo</th>
                <th>Quantità</th>
                <th>Produttore</th>
                <th>Immagine</th>
                <th>Bestseller</th>
                <th>Azioni</th>
              </tr>
            </thead>
            <tbody>
              {prodotti.map((prod) => (
                <tr key={prod.id}>
                  <td>{prod.name}</td>
                  <td>{prod.categoryName}</td>
                  <td>{prod.price} €</td>
                  <td>{prod.quantity}</td>
                  <td>{prod.producer}</td>
                  <td>
                    <img
                      src={getImageUrl(prod.image)}
                      alt={prod.name}
                      style={{ width: 48, height: 32, objectFit: "cover" }}
                      onError={e => {
                        if (e.target.src !== LOGO_PLACEHOLDER) {
                          e.target.onerror = null;
                          e.target.src = LOGO_PLACEHOLDER;
                        }
                      }}
                    />
                  </td>
                  <td>{prod.isBestSeller ? "⭐" : ""}</td>
                  <td>
                    <button className="btn btn-warning btn-sm me-2 w-100" onClick={() => handleEdit(prod)}>Modifica</button>
                    <button className="btn btn-danger btn-sm me-2 w-100" onClick={() => handleDelete(prod.id)}>Elimina</button>
                  </td>
                </tr>
              ))}
              {prodotti.length === 0 && (
                <tr>
                  <td colSpan={8} className="text-center">Nessun prodotto disponibile.</td>
                </tr>
              )}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}

export default GestioneProdotti;
