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
          <div className="container">
            <div className="row">
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantPlace" className="card-text">
                  Étterem neve
                </label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantPlace" className="card-text">
                  AsztalID
                </label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantPlace" className="card-text">
                  2024-03-12
                </label>
              </div>
              <div className="col-sm">
                <button type="button" className="cardbtn float-end">
                  Lemond
                </button>
              </div>
            </div>
          </div>
        </div>
      </section>

      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantPlace" className="card-text">
                  UserName
                </label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantPlace" className="card-text">
                  Email
                </label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantPlace" className="card-text">
                  Role
                </label>
              </div>
              <div className="col-sm">
                <button type="button" className="cardbtn float-end">
                  Töröl
                </button>
              </div>
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
              <div className="col d-flex align-items-end">
                <label htmlFor="restaurantStyle" className="card-Altext">
                  Étterem stílusa
                </label>
              </div>
              <div className="col"></div>
              <div className="col">
                <button
                  type="button"
                  className="cardbtn float-end"
                  style={{ margin: "0" }}
                >
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

      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantStyle" className="card-text">
                  Étterem neve
                </label>{" "}
              </div>
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantStyle" className="card-text">
                  ★★★★★
                </label>{" "}
              </div>
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantStyle" className="card-Altext">
                  Étterem címe
                </label>{" "}
              </div>
              <div className="col-sm">
                <button type="button" className="cardbtn float-end">
                  Szerkesztés
                </button>
              </div>
            </div>
          </div>
        </div>
      </section>

      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-md-6">
                <label htmlFor="restaurantName" className="card-text">
                  Étterem név
                </label>
              </div>
              <div className="col-md-6 d-flex justify-content-end">
                <label htmlFor="stars" className="card-text">
                  ★★★★★
                </label>
              </div>
            </div>
            <div className="row">
              <div className="col d-flex align-items-end">
                <label htmlFor="restaurantStyle" className="card-Altext">
                  Étterem stílusa
                </label>
              </div>
              <div className="col d-flex justify-content-end">
                <button className="likebtn">
                  <img
                    src="./public/likebtn.png"
                    style={{ height: "40px", width: "40px" }}
                  />
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

      <section id="main" className="container py-2">
        <div className="row div-card">
          <div className="container">
            <div className="row">
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantPlace" className="card-Altext">
                  AsztalID
                </label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantPlace" className="card-Altext">
                  Férőhely
                </label>
              </div>
              <div className="col-sm d-flex align-items-center">
                <label htmlFor="restaurantPlace" className="card-Altext">
                  IsFoglalt
                </label>
              </div>
              <div className="col-sm">
                <button type="button" className="cardbtn float-end">
                  Töröl
                </button>
              </div>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}
