import "../App.css";
import React, { useEffect, useState } from "react";
import Navbar from "../components/Navbar";
import CardCustomerReservation from "../components/CardCustomerReservation";
import CheckAuth from "../common/CheckAuth";
import { useNavigate } from "react-router-dom";

export default function CustomerReservations() {

  const navigate = useNavigate(); 
  const [reservations, setReservations] = useState([]);

  useEffect(() => {
    document.title = "Foglalások | DineTab";
    CheckAuth("customer",navigate)
  }, []);

  useEffect(() => {
    getReservations();
  },[reservations])

  const goToMainPageCustomer = () => {
    window.open("/mainPageCustomer", "_self");
  };

  

  const getReservations = async () => {
    const myHeaders = new Headers();

    const requestOptions = {
      method: "GET",
      headers: myHeaders,
      redirect: "follow",
      credentials: 'include',
      xhrFields: { withCredentials: true }
    };

    try {
      const response = await fetch("https://localhost:7114/api/Reservation/getReservationsForLoggedInUser", requestOptions);
      const data = await response.json();
      setReservations(data);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div className="min-vh-100">
      <Navbar />
      {reservations.length === 0 ? (
        <>
          <label className="placeholerLabel">Még nincsenek foglalások</label>
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
            {reservations.map((reservation) => (
              <div className="col-12 mb-3" key={reservation.id}>
                <CardCustomerReservation data={reservation} />
              </div>
            ))}
          </div>
        </section>
      )}
    </div>
  );
}