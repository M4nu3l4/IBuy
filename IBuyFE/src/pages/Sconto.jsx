import { useState, useEffect } from 'react';
import Alert from 'react-bootstrap/Alert';
import Button from 'react-bootstrap/Button';

function AlertDismissible() {
  const [show, setShow] = useState(true);
  const [loggedIn, setLoggedIn] = useState(false);

  useEffect(() => {
    
    const user = localStorage.getItem("user");
    setLoggedIn(!!user);
  }, []);

  if (loggedIn) return null; 

  return (
    <>
      <Alert show={show} variant="success" className="mb-4">
        <Alert.Heading>Welcome to I-Buy! </Alert.Heading>
        <p>
          Per te che ti registri oggi, un codice sconto del 10% sul tuo primo acquisto! Usa il codice <strong>IBUY10</strong> al checkout.
        </p>
        <hr />
        <div className="d-flex justify-content-end">
          <Button onClick={() => setShow(false)} variant="outline-success">
            Chiudi
          </Button>
        </div>
      </Alert>
    </>
  );
}

export default AlertDismissible;
