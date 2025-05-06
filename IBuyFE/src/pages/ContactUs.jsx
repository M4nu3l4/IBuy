import React, { useState } from "react";
import { Form, Button, Alert, Container } from "react-bootstrap";

function ContactUs() {
  const [formData, setFormData] = useState({
    nome: "",
    email: "",
    messaggio: ""
  });

  const [success, setSuccess] = useState(false);
  const [error, setError] = useState("");

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!formData.nome || !formData.email || !formData.messaggio) {
      setError("Tutti i campi sono obbligatori.");
      return;
    }

    setError("");
    setSuccess(true);
    setFormData({ nome: "", email: "", messaggio: "" });
  };

  return (
    <Container className="my-5">
      <h1 className="text-center">Contattaci</h1>
      <p className="text-center"> Hai bisogno di aiuto o vuoi inviarci un feedback? Compila il modulo qui sotto e ti risponderemo al più presto.</p>

      {success && <Alert variant="success">Messaggio inviato con successo!</Alert>}
      {error && <Alert variant="danger">{error}</Alert>}

      <Form onSubmit={handleSubmit} className="mt-4">
        <Form.Group controlId="formNome" className="mb-3">
          <Form.Label>Nome</Form.Label>
          <Form.Control
            type="text"
            name="nome"
            value={formData.nome}
            onChange={handleChange}
            placeholder="Inserisci il tuo nome"
          />
        </Form.Group>

        <Form.Group controlId="formEmail" className="mb-3">
          <Form.Label>Email</Form.Label>
          <Form.Control
            type="email"
            name="email"
            value={formData.email}
            onChange={handleChange}
            placeholder="Inserisci la tua email"
          />
        </Form.Group>

        <Form.Group controlId="formMessaggio" className="mb-3">
          <Form.Label>Messaggio</Form.Label>
          <Form.Control
            as="textarea"
            rows={5}
            name="messaggio"
            value={formData.messaggio}
            onChange={handleChange}
            placeholder="Scrivi il tuo messaggio qui"
          />
        </Form.Group>

        <Button variant="primary" type="submit">Invia</Button>
      </Form>
    </Container>
  );
}

export default ContactUs;


  