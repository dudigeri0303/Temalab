import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/OwnerNavbar";

export default function OwnerTables() {
  useEffect(() => {
    document.title = " Asztalok | DineTab";
  }, []);

  return (
    <>
    <Navbar></Navbar>
    <label className="placeholerLabel">Még nincsenek foglalások</label>

    </>
    );
  }