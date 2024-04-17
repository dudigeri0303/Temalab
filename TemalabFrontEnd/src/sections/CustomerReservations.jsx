import "../App.css";
import React, { useEffect, useState } from "react";
import Navbar from "../components/Navbar";
import CardCustomerReservation from "../components/CardCustomerReservation";

export default function CustomerReservations() {
  useEffect(() => {
    document.title = "Foglalások | DineTab";
    getReservations();
  }, []);

  const [reservations, setReservations] = useState([]);

  const getReservations = async () => {
    const myHeaders = new Headers();

    const requestOptions = {
      method: "GET",
      headers: myHeaders,
      redirect: "follow",
      credentials: 'include',
      xhrFields: { withCredentials: true}
    };

    try {
      const response = await fetch("https://localhost:7114/api/Reservation/getReservationsForLoggedInUser", requestOptions);
      const data = await response.json();
      setReservations(data); 
      console.log(data);
    } catch (error) {
      console.error(error);
    }
  };

  //getReservations();

  {
    /*foglalások betöltése adatbázisból, ha nincs, akkor a lenti label és link jelenik meg, mint placeholder*/
  }

return (
  <>
    <Navbar />
    {reservations.length === 0 ? (
      <>
        <label className="placeholerLabel">Még nincsenek foglalások</label>
      <div className="col-sm d-flex justify-content-center">
        <a className="a-links" href="/mainPageCustomer">
          Éttermek megtekintése
        </a>
      </div>
      </>
    ) : (
      <section id="main" className="container py-2">
        <div className="row">
          {reservations.map((reservation) => (
            <div className="col-12 mb-3" key={reservation.id}>
              <CardCustomerReservation data={reservation} />
            </div>
          ))}
        </div>
      </section>
    )}
  </>
);
}