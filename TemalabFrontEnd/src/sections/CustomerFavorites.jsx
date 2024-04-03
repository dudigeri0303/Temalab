import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/Navbar";

export default function CustomerFavorites() {
  useEffect(() => {
    document.title = " Kedvencek | DineTab";
  }, []);

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
      const result = await response.text();
      console.log(result)
    } catch (error) {
      console.error(error);
    }
  };

  //getFavouriteRestaurants();

  {
    /*kedvencek betöltése adatbázisból, ha nincs, akkor a lenti label és link jelenik meg, mint placeholder*/
  }

  return (
    <>
      <Navbar></Navbar>
      <label className="placeholerLabel">Még nincsenek foglalások</label>
      <div className="col-sm d-flex justify-content-center">
        <a className="a-links" href="/mainPageCustomer">
          Éttermek megtekintése
        </a>
      </div>
    </>
  );
}