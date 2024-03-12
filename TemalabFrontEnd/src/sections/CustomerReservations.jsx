import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/Navbar";

export default function CustomerReservations() {
  useEffect(() => {
    document.title = "Foglalások | DineTab";
  }, []);
  return (
    <>
    <Navbar></Navbar>
    </>
    );
  }