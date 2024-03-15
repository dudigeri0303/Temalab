import "../App.css";
import React, { useEffect, useState } from "react";
import Navbar from "../components/Navbar";
import TimePicker from "react-time-picker";
import "react-time-picker/dist/TimePicker.css";
import "react-clock/dist/Clock.css";

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
  };

  {
    /*kicsit duplikált, de így tud csak frissülni mindkét select*/
  }
  const [openHour, setOpenHour] = useState("0:00");
  const [closeHour, setCloseHour] = useState("23:59");

  const openingTime = (time) => {
    setOpenHour(time);
  };

  const closingTime = (time) => {
    setCloseHour(time);
  };


  var daysWithOpeningHours = {
    "Hétfő": "zárva",
    "Kedd": "zárva",
    "Szerda": "zárva",
    "Csütörtök": "zárva",
    "Péntek": "zárva",
    "Szombat": "zárva",
    "Vasárnap": "zárva",
  };

  const addDayOpeningHour = () => {
    {
      const selectedDay = document.getElementById("days").value;
      const selectedOpenHour = openHour;
      const selectedCloseHour = closeHour;

      const openingHours = selectedOpenHour + "-" + selectedCloseHour;

      daysWithOpeningHours[selectedDay] = openingHours;
    
      for (const [key, value] of Object.entries(daysWithOpeningHours)) {
        console.log(key, value);
      }
    }
  };

  return (
    <>
      <Navbar></Navbar>
      <section id="main" className="container py-3">
        <form method="post">
          <div></div>
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

          <div className="row">
            <div className="col-md-5">
              <div className="mb-3">
                <div className="col-md-4">
                  <label htmlFor="days" className="form-label">
                    Nyitvatartás
                  </label>
                  <select className="form-select" id="days" name="days">
                    <option defaultValue>Napok...</option>
                    <option value="Hétfő">Hétfő</option>
                    <option value="Kedd">Kedd</option>
                    <option value="Szerda">Szerda</option>
                    <option value="Csütörtök">Csütörtök</option>
                    <option value="Péntek">Péntek</option>
                    <option value="Szombat">Szombat</option>
                    <option value="Vasárnap">Vasárnap</option>
                  </select>
                </div>
              </div>
            </div>
            <div className="col-md-2">
              <div>
                <label className="label-time">Nyitás:</label>
                <TimePicker
                  id="openHour"
                  onChange={openingTime}
                  value={openHour}
                />
              </div>
            </div>
            <div className="col-md-2">
              <div className="mb-3">
                <label className="label-time">Zárás:</label>
                <TimePicker
                  id="closeHour"
                  onChange={closingTime}
                  value={closeHour}
                />
              </div>
            </div>
            <div className="col-md-3 offset-sm-4 mb-2">
              <button
                onClick={addDayOpeningHour}
                type="button"
                className="avgbtn"
              >
                Hozzáad
              </button>
            </div>
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
              <button
                onClick={addRestaurantToList}
                type="button"
                className="avgbtn"
              >
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
