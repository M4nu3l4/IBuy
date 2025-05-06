import React, { useState } from "react";

const LavoraConNoi = () => {
  const [nome, setNome] = useState("");
  const [email, setEmail] = useState("");
  const [messaggio, setMessaggio] = useState("");
  const [file, setFile] = useState(null);
  const [fileInputKey, setFileInputKey] = useState(Date.now()); 
  const [success, setSuccess] = useState(false);
  const [error, setError] = useState("");

  const handleFileChange = (e) => {
    const selected = e.target.files[0];
    if (selected && selected.type !== "application/pdf") {
      setError("Puoi allegare solo file PDF.");
      setFile(null);
    } else {
      setError("");
      setFile(selected);
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!nome || !email || !messaggio || !file) {
      setError("Tutti i campi sono obbligatori.");
      return;
    }
    setSuccess(true);
    setError("");
    setNome("");
    setEmail("");
    setMessaggio("");
    setFile(null);
    setFileInputKey(Date.now()); 
  };

  return (
    <div className="container my-5 py-4 bg-white rounded shadow" style={{ maxWidth: 600 }}>
      <h1 className="mb-4 text-center fw-bold">Lavora con noi</h1>
      <p>
        Vuoi entrare a far parte del team <strong>IBuy</strong>? Compila il form e allega il tuo curriculum in formato PDF.
      </p>
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label className="form-label">Nome e Cognome  </label>
          <input
            type="text"
            className="form-control"
            value={nome}
            onChange={(e) => setNome(e.target.value)}
            required
            maxLength={60}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Email</label>
          <input
            type="email"
            className="form-control"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
            maxLength={60}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Messaggio di presentazione</label>
          <textarea
            className="form-control"
            rows={4}
            value={messaggio}
            onChange={(e) => setMessaggio(e.target.value)}
            required
            maxLength={600}
            placeholder="Raccontaci qualcosa su di te!"
          />
        </div>
        <div className="mb-3">
          <label className="form-label"><strong>Curriculum (solo PDF)</strong>  </label>
          <input
            key={fileInputKey}
            type="file"
            accept=".pdf"
            className="form-control"
            onChange={handleFileChange}
            required
          />
        </div>
        {error && <div className="alert alert-danger">{error}</div>}
        {success && (
          <div className="alert alert-success">
            <strong>La tua candidatura è stata inviata con successo! Grazie per averci contattato.</strong>
          </div>
        )}
        <button type="submit" className="btn btn-primary w-100 mt-2">
          Invia candidatura
        </button>
      </form>
    </div>
  );
};

export default LavoraConNoi;
