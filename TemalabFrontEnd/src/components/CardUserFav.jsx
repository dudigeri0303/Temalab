import "../App.css";
import React from 'react';
import PropTypes from 'prop-types'; // Import PropTypes


//Kicsit szét barmoltam a kártyát, de az adatkötés működik a json response alapján
export default function CardUserFav({ data }) {
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
                <label className="card-text">{data.description}</label>
              </div>
            </div>
            <div className="row">
              <div className="col d-flex align-items-end">
                <label className="card-Altext">GyorsÉtterem</label>
              </div>
              <div className="col">
                <button
                  type="button"
                  className="cardbtn float-end"
                  style={{ margin: "0" }}
                >
                  Törlés
                </button>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <label className="card-Altext">{data.city}</label>
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
    name: PropTypes.string.isRequired,
    //rating: PropTypes.string.isRequired,
    description: PropTypes.string.isRequired,
    //buttonText: PropTypes.string.isRequired,
    city: PropTypes.string.isRequired,
  }).isRequired,
};