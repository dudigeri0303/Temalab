import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/Navbar";
import SearchByName from "../components/SearchByName";
import CardCustomerMain from "../components/CardCustomerMain";
import AllRestaurants from "../components/AllRestaurants";
import { useNavigate } from "react-router-dom";
import CryptoJS from 'crypto-js';
import CheckAuth from "../common/CheckAuth";

export default function CustomerMain() {

  const navigate = useNavigate();

  useEffect(() => {
    document.title = " Főoldal | DineTab";
    console.log("asd:" + CryptoJS.AES.decrypt(localStorage.getItem('loggedIn'),'kulcs').toString(CryptoJS.enc.Utf8))
    CheckAuth("customer",navigate)
  }, []);

  return (
    <div className="min-vh-100">
      <Navbar />

      <AllRestaurants>
        {/* itt a lényeg annyi, mint a modalnal is children és akkor így látja a listát, mert olyan, mintha 
        belepakolnád az AllRestaurants belsejébe */}
        {/* dependecy injection itt kapja meg az éttermek listát */}
        {(restaurants) => (
          <>
            <SearchByName restaurantList={restaurants} />
            {restaurants.length === 0 ? (
              <>
                <label className="placeholerLabel">Éttermek</label>
              </>
            ) : (
              <section id="main" className="container py-2">
                <div className="row">
                  {restaurants.map((restaurant) => (
                    <div className="col-12 mb-3" key={restaurant.id}>
                      <CardCustomerMain data={restaurant} />
                    </div>
                  ))}
                </div>
              </section>
            )}
          </>
        )}
      </AllRestaurants>
    </div>
  );
}
