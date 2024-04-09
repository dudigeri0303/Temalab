import "../App.css";
import PropTypes from 'prop-types'; 

export default function CardOwnerMain({data}) {
  return (
    <>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">{data.name}</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">{data.label}</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-Altext">{data.location}</label>
              </div>
              <div className="col-sm">
                <button type="button" className="cardbtn float-end">
                  Szerkesztés
                </button>
              </div>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}

CardOwnerMain.propTypes = {
  data: PropTypes.shape({
  id: PropTypes.string.isRequired,
  name: PropTypes.string.isRequired,
  desctiption: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  location: PropTypes.string.isRequired
  }).isRequired,
};
