import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/OwnerNavbar";

export default function OwnerTables() {
  useEffect(() => {
    document.title = " Asztalok | DineTab";
  }, []);

  const createTableEvent = () => {
    window.open("/createTable", "_self");
  };

  return (
    <>
    <Navbar></Navbar>
    <label className="placeholerLabel">Még nincsenek Asztalok</label>
    <div className="col-sm d-flex justify-content-center">
        <button type="button" onClick={createTableEvent} className="cardbtn">
        ＋ Új asztal hozzáadása 
        </button>
      </div>
    </>
    );
  }