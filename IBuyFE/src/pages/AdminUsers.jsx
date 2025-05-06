import { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const AdminUsers = () => {
  const [users, setUsers] = useState([]);
  const [error, setError] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    const stored = localStorage.getItem("user");
    const user = stored ? JSON.parse(stored) : null;

    if (!user || !user.roles || !user.roles.includes("AdminOffice")) {
      navigate("/login");
    } else {
      toast.success(`Benvenuto ${user.user}!`, {
        position: "top-right",
        autoClose: 3000,
      });
      fetchUsers(user.token);
    }
  }, [navigate]);

  const fetchUsers = async (token) => {
    try {
      const response = await axios.get("https://localhost:7279/api/admin/users", {
        headers: { Authorization: `Bearer ${token}` },
      });
      setUsers(response.data);
    } catch (err) {
      setError("Errore nel recupero utenti.");
    }
  };

  const handleAssignRole = async (e) => {
    e.preventDefault();
    const email = e.target.email.value;
    const role = e.target.role.value;

    try {
      const user = JSON.parse(localStorage.getItem("user"));
      const token = user?.token;

      await axios.post(
        "https://localhost:7279/api/admin/assign-role",
        { email, role },
        { headers: { Authorization: `Bearer ${token}` } }
      );

      toast.success(`Ruolo "${role}" assegnato a ${email}`, {
        position: "top-center",
        autoClose: 3000,
      });

      fetchUsers(token);
    } catch (err) {
      toast.error("Errore durante l'assegnazione del ruolo.", {
        position: "top-center",
        autoClose: 3000,
      });
    }
  };

  const handleDeleteUser = async (email) => {
    if (!window.confirm(`Vuoi davvero eliminare l'utente ${email}?`)) return;
    const user = JSON.parse(localStorage.getItem("user"));
    const token = user?.token;

    try {
      await axios.delete(
        `https://localhost:7279/api/admin/delete-user?email=${encodeURIComponent(email)}`,
        { headers: { Authorization: `Bearer ${token}` } }
      );
      
      
      toast.success(`Utente "${email}" eliminato`, {
        position: "top-center",
        autoClose: 2000,
      });
      fetchUsers(token);
    } catch (err) {
      toast.error("Errore durante l'eliminazione dell'utente.", {
        position: "top-center",
        autoClose: 3000,
      });
    }
  };

  return (
    <div className="container mt-5">
      <ToastContainer />
      <h3 className="mb-4">Gestione Utenti</h3>
      {error && <div className="alert alert-danger">{error}</div>}
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>Email</th>
            <th>Username</th>
            <th>Ruoli</th>
            <th>Azioni</th>
          </tr>
        </thead>
        <tbody>
          {users.map((u, i) => (
            <tr key={i}>
              <td>{u.email}</td>
              <td>{u.userName}</td>
              <td>{u.roles.join(", ")}</td>
              <td>
                {/* 👇 CESTINO */}
                <button
                  className="btn btn-outline-danger btn-sm"
                  title="Elimina utente"
                  onClick={() => handleDeleteUser(u.email)}
                >
                  <i className="bi bi-trash3"></i>
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      <h4 className="mt-5">Assegna un ruolo a un utente</h4>
      <form className="row g-3 mt-2" onSubmit={handleAssignRole}>
        <div className="col-md-6">
          <input
            type="email"
            name="email"
            placeholder="Email utente"
            className="form-control"
            required
          />
        </div>
        <div className="col-md-4">
          <select name="role" className="form-select" required>
            <option value="">Seleziona ruolo</option>
            <option value="Cliente">Cliente</option>
            <option value="AdminOffice">AdminOffice</option>
            <option value="AdminBe">AdminBe</option>
            <option value="AdminFe">AdminFe</option>
          </select>
        </div>
        <div className="col-md-2">
          <button type="submit" className="btn btn-success w-100">
            Assegna
          </button>
        </div>
      </form>
    </div>
  );
};

export default AdminUsers;
