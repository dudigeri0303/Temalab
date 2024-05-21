import "../App.css";
import React, { useEffect, useState } from "react";
import Navbar from "../components/Navbar";
import CardUserFav from "../components/CardUserFav";
import CheckAuth from "../common/CheckAuth";
import { useNavigate } from "react-router-dom";

export default function CustomerFavorites() {

  const navigate = useNavigate(); 

  useEffect(() => {
    document.title = "Kedvencek | DineTab";
    getFavouriteRestaurants();
    CheckAuth("customer",navigate)
  }, []);

  const goToMainPageCustomer = () => {
    window.open("/mainPageCustomer", "_self");
  };

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
      const data = await response.json();
      setRestaurants(data);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div className="min-vh-100">
      <Navbar />
      {restaurants.length === 0 ? (
        <>
          <label className="placeholerLabel">Még nincsenek kedvenc éttermeid</label>
          <div className="col-sm d-flex justify-content-center p-5">
            <button onClick={goToMainPageCustomer}
              type="button"
              className="avgbtn"
            >
              Éttermek megtekintése
            </button>
          </div>
        </>
      ) : (
        <section id="main" className="container py-2">
          <div className="row">
            {restaurants.map((restaurant) => (
              <div className="col-12 mb-3" key={restaurant.id}>
                <CardUserFav data={restaurant} />
              </div>
            ))}
          </div>
        </section>
      )}
    </div>
  );
}