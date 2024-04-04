import "../App.css";
//import React from 'react';
import PropTypes from 'prop-types'; // Import PropTypes


//Kicsit szétbarmoltam a kártyát, de az adatkötés működik a json response alapján
export default function CardUserFav({ data }) {
  const deleteFavouriteRestaurant = async (likedRestaurantId) => {
    const myHeaders = new Headers();

    const requestOptions = {
      method: "DELETE",
      headers: myHeaders,
      credentials: 'include',
      xhrFields: { withCredentials: true},
      redirect: "follow"
    };

    try {
      const response = await fetch("https://localhost:7114/api/LikedRestaurant/deleteLikedRestaurantForLoggedUser?likedRestaurantId=" + likedRestaurantId, requestOptions);
      const result = await response.text();
      console.log(result);
      //window.location.reload();
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-md-3">
                <label className="card-text">{data.name}</label>
              </div>
              <div className="col-md-4">
                <label className="card-text">{data.label}</label>
              </div>
            </div>
            <div className="row">
              <div className="col d-flex align-items-end">
                <label className="card-Altext">{data.description}</label>
              </div>
              <div className="col">
                <button
                  type="button"
                  onClick={() => deleteFavouriteRestaurant(data.id) }
                  className="cardbtn float-end"
                  style={{ margin: "0" }}
                >
                  Törlés
                </button>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <label className="card-Altext">{data.location}</label>
              </div>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}

// PropTypes validation
CardUserFav.propTypes = {
  data: PropTypes.shape({
    id: PropTypes.string.isRequired,
    name: PropTypes.string.isRequired,
    label: PropTypes.string.isRequired,
    description: PropTypes.string.isRequired, 
    location: PropTypes.string.isRequired
  }).isRequired,
};