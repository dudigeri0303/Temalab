import "../App.css";
import React, { useEffect, useState } from "react";
import Navbar from "../components/Navbar";
import SearchByName from "../components/SearchByName";
import CardCustomerMain from "../components/CardCustomerMain";

export default function CustomerFavorites() {
  useEffect(() => {
    document.title = " Főoldal | DineTab";
    getRestaurants();
  }, []);

  const [restaurants, setRestaurants] = useState([]);

  const getRestaurants = async () => {
    const myHeaders = new Headers();
    const requestOptions = {
      method: "GET",
      headers: myHeaders,
      credentials: 'include',
      xhrFields: { withCredentials: true},
      redirect: "follow"
    };
    
    try {
      const response = await fetch("https://localhost:7114/api/Restaurant/listAllRestaurants", requestOptions);
      const data = await response.json();
      setRestaurants(data); 
      console.log(data)
    } catch (error) {
      console.error(error);
    }
  };


  {
    /*éttermek betöltése adatbázisból*/
  }

  return (
    <>
    <Navbar></Navbar>
    <SearchByName></SearchByName>
    {restaurants.length === 0 ? (
      <>
        <label className="placeholerLabel">Éttermek</label>
      </>
    ) : (
      <section id="main" className="container py-2">
        <div className="row div-card">
          {restaurants.map((restaurant) => (
            <div className="col-md-4 mb-3" key={restaurant.id}>
              <CardCustomerMain data={restaurant} />
            </div>
          ))}
        </div>
      </section>
    )}
  </>
  );
}


 
 