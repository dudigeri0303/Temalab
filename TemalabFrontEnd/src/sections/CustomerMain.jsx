import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/Navbar";
import SearchByName from "../components/SearchByName";
import CardCustomerMain from "../components/CardCustomerMain";
import AllRestaurants from "../components/AllRestaurants";

export default function CustomerFavorites() {
  useEffect(() => {
    document.title = " Főoldal | DineTab";
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
