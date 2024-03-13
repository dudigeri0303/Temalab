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
    <h1>Kedvencek</h1>
    </>
    );
  }