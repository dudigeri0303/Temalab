import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/Navbar";

export default function AdminDeleteUser() {
  useEffect(() => {
    document.title = "Felhasználó törlése | DineTab";
  }, []);

  return (
    <>
    <Navbar></Navbar>
    <h1>Delete user</h1>
    </>
    );
  }