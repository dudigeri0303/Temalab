import "../App.css";
import PropTypes from 'prop-types';
import React, { useState } from "react";

export default function CardCustomerMain({data}) {

  const [currentImage, setCurrentImage] = useState("/heart-empty.svg");

  const toggleImage = () => {
    setCurrentImage(
      currentImage === "/heart-empty.svg"
        ? "/heart-full.svg"
        : "/heart-empty.svg"
    );
  };

  const likeRestaurant = async (restaurantId) =>{
    const myHeaders = new Headers();

    const requestOptions = {
      method: "POST",
      headers: myHeaders,
      credentials: 'include',
      xhrFields: { withCredentials: true},
      redirect: "follow"
    };

    toggleImage()

    try {
      const response = await fetch("https://localhost:7114/api/LikedRestaurant/likeRestaurantForLoggedInUser?restaurantId=" + restaurantId, requestOptions);
      const result = await response.text();
      console.log(result)
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <>
      <section id="main" className="container py-2 div-card">
          <div className="d-flex justify-content-between">
            <a href={"/restaurant/" + data.id}>
              <div>
                <div>
                  <label className="card-text">{data.name}</label>
                </div>
                <div>
                  <label className="card-text">{data.desctiption}</label>
                </div>
                <div>
                  <label className="card-Altext">{data.label}</label>
                </div>
                <div>
                  <label className="card-Altext">{data.location}</label>
                </div>
              </div>
            </a>
            <div className="d-flex align-items-center">
              <button className="likebtn" type = "button" onClick={() => likeRestaurant(data.id)}>
                <img
                  src={currentImage}
                  style={{ height: "40px", width: "40px" }}
                />
              </button>
            </div>
          </div>
      </section>
    </>
  );
}

CardCustomerMain.propTypes = {
  data: PropTypes.shape({
  id: PropTypes.string.isRequired,
  name: PropTypes.string.isRequired,
  desctiption: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  location: PropTypes.string.isRequired
  }).isRequired,
};
