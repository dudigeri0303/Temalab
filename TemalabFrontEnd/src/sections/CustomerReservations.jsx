import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/Navbar";

export default function CustomerReservations() {
  useEffect(() => {
    document.title = "Foglalások | DineTab";
  }, []);
  {
    /*foglalások betöltése adatbázisból, ha nincs, akkor a lenti label és link jelenik meg, mint placeholder*/
  }
  return (
    <>
      <Navbar></Navbar>
      <label className="placeholerLabel">Még nincsenek foglalások</label>
      <div className="col-sm d-flex justify-content-center">
        <a className="a-links" href="/mainPageCustomer">
          Éttermek megtekintése
        </a>
      </div>
    </>
  );
}