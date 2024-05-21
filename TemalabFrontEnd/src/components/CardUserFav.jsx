import { useEffect } from "react";
import "../App.css";
import PropTypes from 'prop-types';

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
    } catch (error) {
      console.error(error);
    }
    window.location.reload()
  };

  return (
    <>
      <section id="main" className="container py-2">
        <div className="position-relative">
          <a href={"/restaurant/" + data.restaurantId}>
            <div className="d-flex flex-sm-row justify-content-between div-card">
                <div className="maincardmargin">
                  <div>
                    <label className="card-text">{data.name}</label>
                  </div>
                  <div>
                    <label className="card-text">{data.label}</label>
                  </div>
                  <div>
                    <label className="card-Altext">{data.description}</label>
                  </div>
                  <div>
                    <label className="card-Altext">{data.location}</label>
                  </div>
                </div>
            </div>
          </a>
          <div className="d-flex align-items-center">
            <div className="col">
              <button
                type="button"
                onClick={() => deleteFavouriteRestaurant(data.id) }
                className="cardbtn position-absolute likepos"
                style={{ margin: "0" }}
              >
                Törlés
              </button>
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