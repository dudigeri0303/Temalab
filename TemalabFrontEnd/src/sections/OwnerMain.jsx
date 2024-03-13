import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/OwnerNavbar";

export default function OwnerMain() {
  useEffect(() => {
    document.title = " Főoldal | DineTab";
  }, []);

  return (
    <>
    <Navbar></Navbar>
    <h1>OwnerMain</h1>
    </>
    );
  }