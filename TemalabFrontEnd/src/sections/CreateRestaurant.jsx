import "../App.css";
import React, { useEffect } from "react";
import Navbar from "../components/Navbar";

export default function CreateRestaurant() {
  useEffect(() => {
    document.title = "Étterem hozzáadás | DineTab";
  }, []);

  const backToRestaurantOwner = () => {
    window.open("/mainPageOwner", "_self");
  };

  const addRestaurantToList = () => {
    {
      /*új étterem listához adása a DB-ben, validálást a mezők végezzék*/
    }
    alert("Étterem hozzáadva");
    window.open("/mainPageOwner", "_self");
  }

  {
    /*nyitvatartásra valami megoldás*/
  }

  return (
    <>
      <Navbar></Navbar>
      <section id="main" className="container py-3">
        <form method="post">
          <div className="mb-3">
            <label htmlFor="nameForRestaurant" className="form-label">
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
            <label htmlFor="openingHoursForRestaurant" className="form-label">
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

          <label className="form-label">Cím</label>

          <div className="row">
            <div className="col-md-2">
              <div className="mb-3">
                <label htmlFor="postalCodeForRestaurant" className="form-label">
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
                <label htmlFor="cityNameForRestaurant" className="form-label">
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
                <label htmlFor="streetNameForRestaurant" className="form-label">
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
                <label htmlFor="houseNumber" className="form-label">
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
            <label htmlFor="phoneNumberForRestaurant" className="form-label">
              Telefonszám
            </label>
            <input
              type="text"
              className="form-control"
              id="phoneNumberForRestaurant"
              name="phoneNumberForRestaurant"
              placeholder="Telefonszám"
            />
          </div>

          <div className="mb-3">
            <label htmlFor="descriptionForRestaurant" className="form-label">
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
              <button onClick={addRestaurantToList} type="button" className="avgbtn">
                Létrehoz
              </button>
            </div>
            <div className="col-md-2 mb-2">
              <button
                onClick={backToRestaurantOwner}
                type="button"
                className="avgbtn"
              >
                Mégse
              </button>
            </div>
          </div>
        </form>
      </section>
    </>
  );
}