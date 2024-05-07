import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/OwnerNavbar";
import CardOwnerMain from "../components/CardOwnerMain";
import SearchByName from "../components/SearchByName";
import OwnerRestaurants from "../components/OwnerRestaurants";

export default function OwnerMain() {
  useEffect(() => {
    document.title = " Főoldal | DineTab";
  }, []);

  const createRestEvent = () => {
    window.open("/createRestaurant", "_self");
  };

  return (
    <>
      <div className="min-vh-100">
        <Navbar />
        <OwnerRestaurants>
          {(restaurants) => (
            <>
              <SearchByName restaurantList={restaurants} />
              {restaurants.length === 0 ? (
                <label className="placeholerLabel">
                  Még nincsenek éttermek
                </label>
              ) : (
                <section id="main" className="container py-2">
                  <div className="row">
                    {restaurants.map((restaurant) => (
                      <div className="col-12 mb-3" key={restaurant.id}>
                        <CardOwnerMain data={restaurant} />
                      </div>
                    ))}
                  </div>
                </section>
              )}
            </>
          )}
        </OwnerRestaurants>
      </div>
      <div className="col-sm d-flex justify-content-center">
        <button type="button" onClick={createRestEvent} className="cardbtn">
          ＋ Új étterem hozzáadása
        </button>
      </div>
    </>
  );
}
