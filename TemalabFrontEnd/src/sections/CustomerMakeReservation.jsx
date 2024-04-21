import "../App.css";
import React, { useEffect, useState } from "react";
import Navbar from "../components/Navbar";
import TimePicker from "react-time-picker";

export default function CustomerMakeReservations() {
  useEffect(() => {
    document.title = "Étterem foglalás | DineTab";
  }, []);

  const today = new Date().toISOString().split('T')[0];

  return (
    <div>
      <Navbar />
      <input type="date" id="start" name="trip-start" value={today} min={today} max="2028-12-31" />
        <TimePicker />
    </div>
  );
}
