import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/Navbar";

export default function CreateRestaurant() {
  useEffect(() => {
    document.title = "Étterem hozzáadás | DineTab";
  }, []);
  return (
    <>
    <Navbar></Navbar>
      <section id="main" className="container py-3">

        <form method="post">
          <div className="mb-3">
            <label htmlFor="inputName" className="form-label">
              Étterem név
            </label>
            <input
              type="text"
              className="form-control"
              id="nameForRestaurant"
              name="nameForRestaurant"
              placeholder="Étterem név"
              required
            />
          </div>

          <div className="mb-3">
            <label htmlFor="inputOpeningHours" className="form-label">
              Nyitvatartás
            </label>
            <input
              type="text"
              className="form-control"
              id="openingHoursForRestaurant"
              name="openingHoursForRestaurant"
              placeholder="Nyitvatartás API vagy szövegdoboz vagy select menü"
            />
          </div>

          <label htmlFor="inputName" className="form-label">
            Cím
          </label>

          <div className="row">
            <div className="col-md-2">
              <div className="mb-3">
                <label htmlFor="inputPostalCode" className="form-label">
                  Irányítószám
                </label>
                <input
                  type="number"
                  className="form-control"
                  id="postalCodeForRestaurant"
                  name="postalCodeForRestaurant"
                  placeholder="Irányítószám"
                  required
                />
              </div>
            </div>
            <div className="col-md-4">
              <div className="mb-3">
                <label htmlFor="inputCity" className="form-label">
                  Város
                </label>
                <input
                  type="text"
                  className="form-control"
                  id="cityNameForRestaurant"
                  name="cityNameForRestaurant"
                  placeholder="Város"
                  required
                />
              </div>
            </div>
            <div className="col-md-4">
              <div className="mb-3">
                <label htmlFor="intputStreet" className="form-label">
                  Utca
                </label>
                <input
                  type="text"
                  className="form-control"
                  id="streetNameForRestaurant"
                  name="streetNameForRestaurant"
                  placeholder="Utca"
                  required
                />
              </div>
            </div>
            <div className="col-md-2">
              <div className="mb-3">
                <label htmlFor="inputHouseNumber" className="form-label">
                  Házszám
                </label>
                <input
                  type="text"
                  className="form-control"
                  id="houseNumber"
                  name="houseNumber"
                  placeholder="Házszám"
                  required
                />
              </div>
            </div>
          </div>

          <div className="col-md-6 mb-3">
            <label htmlFor="inputPhoneNumber" className="form-label">
              Telefonszám
            </label>
            <input
              type="tel"
              className="form-control"
              id="phoneNumberForRestaurant"
              name="phoneNumberForRestaurant"
              placeholder="Telefonszám"
            />
          </div>

          <div className="mb-3">
            <label htmlFor="inputDescription" className="form-label">
              Leírás
            </label>
            <textarea
              type="text"
              className="form-control"
              id="descriptionForRestaurant"
              name="descriptionForRestaurant"
              placeholder="Leírás"
            />
          </div>

          <div className="row">
            <div className="col-md-3 offset-sm-4 mb-2">
              <button type="submit" className="avgbtn">
                Létrehoz
              </button>
            </div>
            <div className="col-md-2 mb-2">
              <button type="button" className="avgbtn">
                Mégse
              </button>
            </div>
          </div>
        </form>
      </section>
    </>
  );
}