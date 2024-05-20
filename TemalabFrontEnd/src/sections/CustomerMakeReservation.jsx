import "../App.css";
import React, { useEffect, useState } from "react";
import Navbar from "../components/Navbar";
import TimePicker from "react-time-picker";
import CheckAuth from "../common/CheckAuth";
import { useNavigate, useParams } from "react-router-dom";

export default function CustomerMakeReservations() {

  const navigate = useNavigate(); 

  useEffect(() => {
    document.title = "Étterem foglalás | DineTab";
    CheckAuth("customer",navigate)
  }, []);

  const today = new Date().toISOString().split("T")[0];
  const id = useParams();

  const [datepicker, setDatepicker] = useState(today);
  const [timepicker, setTimepicker] = useState("12:00");
  const [numberOfQuests, setNumberOfQuests] = useState(1);
  const [timeValue, setTimeValue] = useState(1);
  const [descValue, setDescValue] = useState("");

  const descChange = (e) => {
    setDescValue(e.target.value);
  }

  const dateSelected = (e) => {
    const selectedDate = e.target.value;
    setDatepicker(selectedDate);
  };

  const timeSelected = (time) => {
    setTimepicker(time);
  };

  const questsSelected = (event) => {
    setNumberOfQuests((event.target.value));
  };

  const timeValueSelected = (event) => {
    setTimeValue(event.target.value);
  };

  
  const reservetable = async() => {
    const myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    const raw = JSON.stringify({
        "restaurantId": id.id,
        "dateTime": datepicker + " " + timepicker,
        "numOfPeople": numberOfQuests,
        "lenght": timeValue,
        "comment": descValue
    });
    const requestOptions = {
        method: "POST",
        credentials: 'include',
        xhrFields: { withCredentials: true},
        headers: myHeaders,
        mode: 'cors',
        body: raw,
        redirect: "follow"
    };
    try {
        await fetch("https://localhost:7114/api/Reservation/reserveTableForLoggedUser", requestOptions);
        console.log("OK")
        navigate("/customerReservations")
    } catch (error) {
        console.error(error);
    }
  }


  return (
    <>
      <Navbar />
      <div className="row div-card">
        <div className="col-md-3 mb-3 align-self-end">
          <label className="form-label card-Altext" htmlFor="date">
            Dátum
          </label>
          <input
            className="form-control"
            type="date"
            id="date"
            name="date"
            value={datepicker}
            min={today}
            max="2028-12-31"
            onChange={dateSelected}
          />
        </div>
        <div className="col-md-3 mb-3 align-self-end">
          <label className="form-label card-Altext" htmlFor="time">
            Idő
          </label>
          <TimePicker 
          className="form-control"
            id="time"
            value={timepicker}
            onChange={timeSelected} 
          />
        </div>
        <div className="col-md-3 mb-3 align-self-end">
          <label className="form-label card-Altext">Vendégek száma</label>
          <select
            className="form-select"
            id="numberOfQuests"
            name="numberOfQuests"
            style={{ width: "200px" }}
            value={numberOfQuests}
            onChange={questsSelected}
          >
            {Array.from({ length: 99 }, (_self, i) => i + 1).map((number) => (
              <option key={number} value={number}>
                {number} fő
              </option>
            ))}
          </select>
        </div>
        <div className="col-md-3 mb-3 align-self-end">
          <label className="form-label card-Altext">Időtartam</label>
          <select
            className="form-select"
            id="numberOfQuests"
            name="numberOfQuests"
            style={{ width: "200px" }}
            value={timeValue} 
            onChange={timeValueSelected}
          >
            {Array.from({ length: 8 }, (_self, i) => i + 1).map((number) => (
              <option key={number} value={number}>
                {number} óra
              </option>
            ))}
          </select>
        </div>
        <div className="row mb-2">
            <div className="col-12">
              <p className="form-label card-Altext">Megjegyzés</p>
              <textarea onChange={descChange} className="w-100 form-control textares"></textarea>
            </div>
        </div>
        <div className="d-flex justify-content-center">
          <button className="avgbtn" onClick={reservetable}>Elérhetőség ellenőrzése</button>
        </div>
      </div>
    </>
  );
}
