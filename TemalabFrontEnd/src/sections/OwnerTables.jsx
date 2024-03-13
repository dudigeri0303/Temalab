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

  {/*étteremhez rendelt asztalok betöltése adatbázisból, ha nincs, akkor a lenti label jelenik meg, mint placeholder*/}
  {/*createTable még nem létezik majd megfelően, ami a neve lesz, oda irányítson át, ha olyan lesz, mint a createRest*/}

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