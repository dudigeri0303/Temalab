import "../App.css";
import PropTypes from 'prop-types'; 

export default function CardCustomerReservation({ data }) {
  const deleteReservation = async (reservationId)=> {
    const myHeaders = new Headers();

    const requestOptions = {
      method: "DELETE",
      headers: myHeaders,
      credentials: 'include',
      xhrFields: { withCredentials: true},
      redirect: "follow"
    };

    try {
      const response = await fetch("https://localhost:7114/api/Reservation/deleteReservationForLoggedUser?reservationId=" + reservationId, requestOptions);
      const result = await response.text();
      console.log(result)
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
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">{data.restaurantName}</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">{data.tableId}</label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label className="card-text">{data.endDate}</label>
              </div>
              <div className="col-sm">
                <button type="button" className="cardbtn float-end" onClick={() => deleteReservation(data.id)}>
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
  id: PropTypes.string.isRequired,
  restaurantName: PropTypes.string.isRequired,
  tableId: PropTypes.string.isRequired,
  endDate: PropTypes.string.isRequired,
  }).isRequired,
};