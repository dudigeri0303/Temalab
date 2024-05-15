import "../App.css";
import React, { useEffect } from "react";
import OwnerNavbar from "../components/OwnerNavbar";

export default function OwnerManageTables() {

  useEffect(() => {
    document.title = " Asztalok Kezelése | DineTab";
  }, []);



  return (
    <>
    <OwnerNavbar/>

    </>
  );
}
