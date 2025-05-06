import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import { BrowserRouter } from 'react-router-dom';
import { CartProvider } from './contexts/CartContext';
import 'bootstrap/dist/css/bootstrap.min.css';
import { WishlistProvider } from './contexts/WishlistContext';
import './custom-theme.css';


ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <BrowserRouter>
      <CartProvider>   
         <WishlistProvider> 
          <App /> 
          </WishlistProvider>             
      </CartProvider>
    </BrowserRouter>
  </React.StrictMode>
);
