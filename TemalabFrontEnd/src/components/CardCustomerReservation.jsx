import "../App.css";
import PropTypes from 'prop-types'; 

export default function CardCustomerReservation({ data }) {
  return (
    <>
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">{data.restaurantName}</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">{data.tableId}</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">{data.date}</label>
              </div>
              <div className="col-sm">
                <button type="button" className="cardbtn float-end">
                  Lemond
                </button>
              </div>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}

CardCustomerReservation.propTypes = {
  data: PropTypes.shape({
  restaurantName: PropTypes.string.isRequired,
  tableId: PropTypes.string.isRequired,
  date: PropTypes.string.isRequired,
  }).isRequired,
};