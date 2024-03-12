import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/Navbar";

export default function Template() {
  useEffect(() => {
    document.title = "Template | DineTab";
  }, []);
  return (
    <>
    <Navbar></Navbar>
      <section id="main" className="container py-2">

          <div className="row div-card">
            <div className="col-md-4">
              <div className="mb-3">
                <label htmlFor="restaurantName" className="card-text">
                  Étterem neve
                </label>
              </div>
            </div>
            <div className="col-md-2">
              <div className="mb-3">
                <label htmlFor="tableNumber" className="card-text">
                  Asztal ID
                </label>

              </div>
            </div>
            <div className="col-md-3">
              <div className="mb-3">
                <label htmlFor="dateTime" className="card-text">
                  Dátum
                </label>

              </div>
            </div>
            <div className="col-md-2">
              <div className="mb-3">
              <button type="button" className="cardbtn">
                Lemond
              </button>
              </div>
            </div>
          </div>
      </section>
    </>
  );
}