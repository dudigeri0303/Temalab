import "../App.css";
import React, { useEffect, useState } from "react";
import Navbar from "../components/OwnerNavbar";
import CardOwnerMain from "../components/CardOwnerMain";

export default function OwnerMain() {
  useEffect(() => {
    document.title = " Főoldal | DineTab";
    listOwnerRestaurants();
  }, []);

  const [restaurants, setRestaurants] = useState([]);

  const listOwnerRestaurants = async () => {
    const myHeaders = new Headers();

    const requestOptions = {
      method: "GET",
      headers: myHeaders,
      credentials: 'include',
      xhrFields: { withCredentials: true},
      redirect: "follow"
    };

    try {
      const response = await fetch("https://localhost:7114/api/Owner/listRestaurantsByOwner", requestOptions);
      const data = await response.json();
      setRestaurants(data); 
      console.log(data)
    } catch (error) {
      console.error(error);
    }
  };

  const createRestEvent = () => {
    window.open("/createRestaurant", "_self");
  };

  {
    /*éttermek betöltése adatbázisból, ha nincs, akkor a lenti label jelenik meg, mint placeholder*/
  }

  return (
    <>
    <Navbar></Navbar>
    {restaurants.length === 0 ? (
      <>
        <label className="placeholerLabel">Még nincsenek éttermek</label>
      </>
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
      <div className="col-sm d-flex justify-content-center">
        <button type="button" onClick={createRestEvent} className="cardbtn">
          ＋ Új étterem hozzáadása
        </button>
      </div>
  </>
  );
}


/**

  
 */