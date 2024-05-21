import "../App.css";
import PropTypes from "prop-types";

export default function CardCustomerReservation({ data }) {
  const deleteReservation = async (reservationId) => {
    const myHeaders = new Headers();

    const requestOptions = {
      method: "DELETE",
      headers: myHeaders,
      credentials: "include",
      xhrFields: { withCredentials: true },
      redirect: "follow",
    };

    try {
      const response = await fetch(
        "https://localhost:7114/api/Reservation/deleteReservationForLoggedUser?reservationId=" +
          reservationId,
        requestOptions
      );
      const result = await response.text();
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <>
      <div className="container">
        <div className="div-card">
          <div className="row">
            <div className="row col-12 col-md-4">
              <div className="col-12">
                <p className="card-Altext">{data.userName}</p>
              </div>
              <div className="col-12">
                <p className="card-Altext">{data.numOfPeople} Fő</p>
              </div>
              <div className="col-12">
                <p className="card-Altext">{data.dateTime}</p>
              </div>
            </div>
            <div className="row col-12 col-md-4 d-flex justify-content-center align-items-center">
              <div className="col-12">
                <p className="card-Altext">{data.restaurantName}</p>
              </div>
            </div>
            <div className="card-Altext col-12 col-md-4 d-flex justify-content-end align-items-center">
              <button
                type="button"
                className="cardbtn2 float-right"
                onClick={() => deleteReservation(data.id)}
              >
                Lemond
              </button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

CardCustomerReservation.propTypes = {
  data: PropTypes.shape({
    id: PropTypes.string.isRequired,
    restaurantName: PropTypes.string.isRequired,
    restaurantId: PropTypes.string.isRequired,
    dateTime: PropTypes.string.isRequired,
  }).isRequired,
};
