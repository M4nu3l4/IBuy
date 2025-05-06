import { useEffect } from "react";
import { Navigate, Outlet, useLocation } from "react-router-dom";

const AdminRoute = ({ allowedRoles }) => {
  const location = useLocation();
  const user = JSON.parse(localStorage.getItem("user"));

  const isAuthorized = user && allowedRoles.some(role => user.roles?.includes(role));

  useEffect(() => {
    if (!isAuthorized) {
      alert("Accesso negato. Non hai i permessi per accedere a questa pagina.");
    }
  }, [isAuthorized]);

  return isAuthorized ? (
    <Outlet />
  ) : (
    <Navigate to="/login" state={{ from: location }} replace />
  );
};

export default AdminRoute;

