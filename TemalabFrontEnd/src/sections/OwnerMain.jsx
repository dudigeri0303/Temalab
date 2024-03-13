import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/OwnerNavbar";

export default function OwnerMain() {
  useEffect(() => {
    document.title = " Főoldal | DineTab";
  }, []);

  const createRestEvent = () => {
    window.open("/createRestaurant", "_self");
  };

  {/*éttermek betöltése adatbázisból, ha nincs, akkor a lenti label jelenik meg, mint placeholder*/}

  return (
    <>
      <Navbar></Navbar>
      <label className="placeholerLabel">Még nincsenek éttermek</label>
      <div className="col-sm d-flex justify-content-center">
        <button type="button" onClick={createRestEvent} className="cardbtn">
        ＋ Új étterem hozzáadása 
        </button>
      </div>
    </>
  );
}
