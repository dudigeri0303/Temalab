import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/Navbar";

export default function CustomerFavorites() {
  useEffect(() => {
    document.title = " Főoldal | DineTab";
  }, []);

  {
    /*éttermek betöltése adatbázisból*/
  }

  return (
    <>
      <Navbar></Navbar>
      <label className="placeholerLabel">Éttermek</label>
    </>
  );
}