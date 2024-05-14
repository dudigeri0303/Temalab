import "../App.css";
import React, { useEffect, useState } from "react";
import OwnerNavbar from "../components/OwnerNavbar";
import TimePicker from "react-time-picker";
import "react-time-picker/dist/TimePicker.css";
import "react-clock/dist/Clock.css";

export default function CreateRestaurant() {
  useEffect(() => {
    document.title = "Étterem hozzáadás | DineTab";
  }, []);

  const [name, setName] = useState('');
  const [postCode, setPostCode] = useState('');
  const [city, setCity] = useState('');
  const [street, setStreet] = useState('');
  const [houseNumber, setHouseNumber] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [description, setDescription] = useState('');
  const [label, setLabel] = useState('kajálda haha');

  const backToRestaurantOwner = () => {
    window.open("/mainPageOwner", "_self");
  };

  const addRestaurantToList = async () => {
    const myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    const openingHoursArray = Object.entries(daysWithOpeningHours).map(([day, data]) => ({
      dayName: data.dayName,
      openingHour: data.openingHour
    }));

    const raw = JSON.stringify({
      "name": name,
      "postCode": postCode,
      "city": city,
      "street": street,
      "houseNumber": houseNumber,
      "phoneNumber": phoneNumber,
      "description": description,
      "label": label,
      "openingHours" : openingHoursArray
    });

    const requestOptions = {
      method: "POST",
      headers: myHeaders,
      credentials: 'include',
      xhrFields: { withCredentials: true},
      body: raw,
      redirect: "follow"
    };

    try {
      const response = await fetch("https://localhost:7114/api/Owner/createNewRestaurantWithOwner", requestOptions);
      const result = await response.text();
      console.log(result)
    } catch (error) {
      console.error(error);
    }
    alert("Étterem hozzáadva");
    window.open("/mainPageOwner", "_self");
  };

    /*
    kicsit duplikált, de így tud csak frissülni mindkét select
    lehetne mergerlni a 2 useState-et, de elég körülményes
    */
  
  const [openHour, setOpenHour] = useState("0:00");
  const [closeHour, setCloseHour] = useState("23:59");

  const openingTime = (time) => {
    setOpenHour(time);
  };

  const closingTime = (time) => {
    setCloseHour(time);
  };

  {
    /*kulcs értékpárok előre eltárolva, így megadásnál 1 naphoz csak 1 érték adható,
    napok sem duplikálódnak, valamit sorrend is fix, ha nincs megadva nyitvatartás, akkor zárva a default érték*/
  }

  const [daysWithOpeningHours, setDaysWithOpeningHours] = useState({
    Hétfő: {dayName: "Hétfő", openingHour: "zárva"},
    Kedd: {dayName: "Kedd", openingHour: "zárva"},
    Szerda: {dayName: "Szerda", openingHour: "zárva"},
    Csütörtök: {dayName: "Csütörtök", openingHour: "zárva"},
    Péntek:  {dayName: "Péntek", openingHour: "zárva"},
    Szombat: {dayName: "Szombat", openingHour: "zárva"},
    Vasárnap: {dayName: "Vasárnap", openingHour: "zárva"}
  });

  const updateOpeningHours = () => {
    setDaysWithOpeningHours(() => ({
      ...daysWithOpeningHours,
      ...daysWithOpeningHours,
    }));
  };

  //object to array, majd végigmappol a listán és minden kulcshoz/naphoz hozzárendel egy listaelemet-t, ami a nyitvatartást tartalmazza
  const updatedOpeningHours = Object.entries(daysWithOpeningHours).map(
    (day) => <li className="li-oph" key={day[0]}>{day[1].dayName} : {day[1].openingHour}</li>
  );

  const addDayOpeningHour = () => {
    const selectedDay = document.getElementById("days").value;
    const selectedOpenHour = openHour;
    const selectedCloseHour = closeHour;
  
    const openingHours = selectedOpenHour + "-" + selectedCloseHour;
  
    setDaysWithOpeningHours(prevState => ({
      ...prevState,
      [selectedDay]: { ...prevState[selectedDay], openingHour: openingHours }
    }));
  };

  const closeDay = () => {
    const selectedDay = document.getElementById("days").value;
    const openingHours = " zárva";
    daysWithOpeningHours[selectedDay].openingHour = openingHours;
    updateOpeningHours();
  };

  return (
    <>
      <OwnerNavbar></OwnerNavbar>
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
              value={name}
              onChange={(e) => setName(e.target.value)}
              required
            />
          </div>

          <div className="row">
            <div className="col-md-4">
              <div className="mb-3">
                  <label htmlFor="days" className="form-label">
                    Nyitvatartás
                  </label>
                  <select
                    className="form-select"
                    id="days"
                    name="days"
                    style={{ width: "200px" }}
                  >
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
            <div className="col-md-3">
              <div className="mb-3">
                <label className="label-time">Nyitás:</label>
                <TimePicker
                  className="time-pickerStart"
                  id="openHour"
                  onChange={openingTime}
                  value={openHour}
                  clearIcon={null}
                />
              </div>
            </div>
            <div className="col-md-3">
              <div className="mb-3">
                <label className="label-time">Zárás:</label>
                <TimePicker
                  className="time-pickerEnd"
                  id="closeHour"
                  onChange={closingTime}
                  value={closeHour}
                  clearIcon={null}
                />
              </div>
            </div>
            <div className="col-md-2 d-flex justify-content-center">
            <button onClick={closeDay} type="button" className="redbtn">
                Zárva
              </button>
            </div>
          </div>

          <div className="row">
            <div className="col-md-12 d-flex justify-content-center" style={{ padding: '20px' }}>
            <button
                onClick={addDayOpeningHour}
                type="button"
                className="avgbtn"
              >
                Nyitvatartási nap hozzáadása
              </button>
            </div>
          </div>
        
            <div className="col-md-12 d-flex justify-content-center">
              <ul className="ul-days">{updatedOpeningHours}</ul>
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
                  value={postCode}
                  onChange={(e) => setPostCode(e.target.value)}
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
                  value={city}
                  onChange={(e) => setCity(e.target.value)}
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
                  value={street}
                  onChange={(e) => setStreet(e.target.value)}
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
                  value={houseNumber}
                  onChange={(e) => setHouseNumber(e.target.value)}
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
              value={phoneNumber}
              onChange={(e) => setPhoneNumber(e.target.value)}
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
              value={description}
              onChange={(e) => setDescription(e.target.value)}
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
