import React, { useEffect, useState } from "react";
import Navbar from "../components/Navbar";
import CardUserFav from "../components/CardUserFav";

export default function CustomerFavorites() {
  useEffect(() => {
    document.title = "Kedvencek | DineTab";
    getFavouriteRestaurants();
  }, []);

  const [restaurants, setRestaurants] = useState([]);

  const getFavouriteRestaurants = async () =>{
    const myHeaders = new Headers();

    const requestOptions = {
      method: "GET",
      headers: myHeaders,
      redirect: "follow",
      credentials: 'include',
      xhrFields: { withCredentials: true},
    };

    try {
      const response = await fetch("https://localhost:7114/api/LikedRestaurant/getLikedRestaurantForLoggedInUser", requestOptions);
      const data = await response.json(); // Parse JSON directly
      setRestaurants(data); 
      console.log(data);
      
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <>
      <Navbar />
      {restaurants.length === 0 ? (
        <>
          <label className="placeholerLabel">Még nincsenek kedvenc éttermeid</label>
          <div className="col-sm d-flex justify-content-center">
            <a className="a-links" href="/mainPageCustomer">
              Éttermek megtekintése
            </a>
          </div>
        </>
      ) : (
        <section id="main" className="container py-2">
          <div className="row div-card">
            {restaurants.map((restaurant) => (
              <div className="col-md-4 mb-3" key={restaurant.id}>
                <CardUserFav data={restaurant} />
              </div>
            ))}
          </div>
        </section>
      )}
    </>
  );
}