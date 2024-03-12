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
                Hosszú étterem neve
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
                2024-03-12
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
      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="col-md-4">
            <div className="mb-3">
              <label htmlFor="restaurantName" className="card-text">
                FirstName LastName
              </label>
            </div>
          </div>
          <div className="col-md-4">
            <div className="mb-4">
              <label htmlFor="tableNumber" className="card-text">
                Email
              </label>
            </div>
          </div>
          <div className="col-md-2">
            <div className="mb-3">
              <label htmlFor="dateTime" className="card-text">
                Role
              </label>
            </div>
          </div>
          <div className="col-md-2">
            <div className="mb-3">
              <button type="button" className="cardbtn">
                Töröl
              </button>
            </div>
          </div>
        </div>
      </section>

      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-md-3">
                <label htmlFor="restaurantName" className="card-text">
                  Étterem név
                </label>
              </div>
              <div className="col-md-4">
                <label htmlFor="stars" className="card-text">
                ★★★★★
                </label>
              </div>
            </div>
            <div className="row">
              <div className="col" style={{ alignSelf: 'flex-end'}}>
                <label htmlFor="restaurantStyle" className="card-Altext">
                  Étterem stílusa
                </label>
              </div>
              <div className="col"></div>
              <div className="col">
                <button type="button" className="cardbtn float-end" style={{ margin: "0" }}>
                  Eltávolítás
                </button>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <label htmlFor="restaurantPlace" className="card-Altext">
                  Étterem helye
                </label>
              </div>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}
