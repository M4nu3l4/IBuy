// src/contexts/WishlistContext.jsx

import { createContext, useContext, useState, useEffect } from "react";

const WishlistContext = createContext();

export const WishlistProvider = ({ children }) => {
  const [wishlist, setWishlist] = useState([]);

 
  useEffect(() => {
    const saved = localStorage.getItem("wishlist");
    if (saved) {
      setWishlist(JSON.parse(saved));
    }
  }, []);

 
  useEffect(() => {
    localStorage.setItem("wishlist", JSON.stringify(wishlist));
  }, [wishlist]);

  
  const addToWishlist = (product) => {
    
    if (!wishlist.some(item => item.productId === product.id)) {
      setWishlist((prev) => [
        ...prev,
        {
          productId: product.id,
          productName: product.name,
          description: product.description,
          price: product.price,
          image: product.image
        }
      ]);
    }
  };

  const removeFromWishlist = (productId) => {
    setWishlist((prev) => prev.filter(item => item.productId !== productId));
  };

  const isInWishlist = (productId) => {
    return wishlist.some((item) => item.productId === productId);
  };


  return (
    <WishlistContext.Provider value={{
      wishlistItems: wishlist,
      addToWishlist,
      removeFromWishlist,
      isInWishlist
    }}>
      {children}
    </WishlistContext.Provider>
  );
};


export const useWishlist = () => useContext(WishlistContext);


