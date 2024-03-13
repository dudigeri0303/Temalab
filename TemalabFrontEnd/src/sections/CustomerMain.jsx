import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/Navbar";

export default function CustomerFavorites() {
  useEffect(() => {
    document.title = " Főoldal | DineTab";
  }, []);

  return (
    <>
    <Navbar></Navbar>
    <h1>CustomerMain</h1>
    </>
    );
  }