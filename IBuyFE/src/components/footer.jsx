import React from "react";


function Footer() {
  return (
    <footer className="bg-dark text-light text-center py-4 mt-5">
      <div className="container">
        <p className="mb-2">&copy; {new Date().getFullYear()} IBuy Srl. Tutti i diritti riservati.</p>
        <div className="mb-2">
          <a href="/contact-us" className="text-light me-3">Contattaci</a>
          <a href="/lavora-con-noi" className="text-light me-3">Lavora con noi</a>
          <a href="/privacy" className="text-light me-3">Privacy & GDPR</a>
          <a href="/admin" className="text-light">Area Admin</a>
        </div>
        <p className="mb-0 small">Sede legale: Cagliari | P.IVA: 000024681012 | info@ibuy.com</p>
        <p className="small">Servizio clienti: 800123456 - Lun–Sab 9:00–21:00</p>
      </div>
    </footer>
  );
}

export default Footer;

