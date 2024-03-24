import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/Navbar";
import SearchByName from "../components/SearchByName";

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
      <SearchByName></SearchByName>

      <label className="placeholerLabel">Éttermek</label>
    </>
  );
}