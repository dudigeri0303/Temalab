import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/Navbar";

export default function CustomerFavorites() {
  useEffect(() => {
    document.title = " Kedvencek | DineTab";
  }, []);

  return (
    <>
    <Navbar></Navbar>
    <label className="placeholerLabel">Még nincsenek kedvencek</label>
    <a href="/mainPageCustomer">Éttermek megtekintése</a>


    </>
    );
  }