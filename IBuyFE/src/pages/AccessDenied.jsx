import { Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";

const AccessDenied = () => {
  return (
    <div className="container text-center mt-5">
      <h2 className="text-danger">Accesso Negato</h2>
      <p>Non hai i permessi necessari per accedere a questa pagina.</p>
      <Link to="/" className="btn btn-outline-dark mt-3">Torna alla Home</Link>
    </div>
  );
};

export default AccessDenied;
