import "../App.css";
import React, { useEffect } from 'react';

export default function CreateRestaurant() {
    useEffect(() => {
        document.title = 'Étterem hozzáadás | DineTab';
      }, []);
  return (
    <>

      <section id="main" className="container py-3">
        <h1 className="display-3">Create Restaurant</h1>

        <form method="post">
    
          <div className="mb-3">
            <label htmlFor="inputName" className="form-label">Étterem név</label>
            <input
              type="text"
              className="form-control"
              id="nameForRestaurant"
              name="nameForRestaurant"
              aria-describedby="restaurantNameHelp"
              placeholder="Étterem név"
              required
            />
          </div>

          <div className="mb-3">
            <label htmlFor="inputOpeningHours" className="form-label">Nyitvatartás</label>
            <input
              type="text"
              className="form-control"
              id="openingHoursForRestaurant"
              name="openingHoursForRestaurant"
              aria-describedby="openingHoursHelp"
              placeholder="Nyitvatartás API vagy szövegdoboz"
            />
          </div>

          <label htmlFor="inputName" className="form-label">Cím</label>

          <div className="row">
      <div className="col-md-2">
        <div className="mb-3">
          <label htmlFor="inputPostalCode" className="form-label">Irányítószám</label>
          <input
            type="number"
            className="form-control"
            id="irszam"
            aria-describedby="iranyitoSzam"
            name="irszam"
            placeholder="Irányítószám"
            required
          />
        </div>
      </div>
      <div className="col-md-4">
        <div className="mb-3">
          <label htmlFor="inputCity" className="form-label">Város</label>
          <input
            type="text"
            className="form-control"
            id="city"
            name="city"
            placeholder="Város"
            required
          />
        </div>
      </div>
      <div className="col-md-4">
        <div className="mb-3">
          <label htmlFor="intputStreet" className="form-label">Utca</label>
          <input
            type="text"
            className="form-control"
            id="street"
            name="street"
            placeholder="Utca"
            required
          />
        </div>
      </div>
      <div className="col-md-2">
        <div className="mb-3">
          <label htmlFor="inputHouseNumber" className="form-label">Házszám</label>
          <input
            type="password"
            className="form-control"
            id="houseNumber"
            name="houseNumber"
            placeholder="Házszám"
            required
          />
        </div>
      </div>
    </div>

    <div className="mb-3">
            <label htmlFor="inputOpeningHours" className="form-label">Telefonszám</label>
            <input
              type="tel"
              className="form-control"
              id="phoneNumberForRestaurant"
              name="phoneNumberForRestaurant"
              placeholder="Telefonszám"
            />
          </div>

          <div className="mb-3">
            <label htmlFor="inputOpeningHours" className="form-label">Leírás</label>
            <textarea
              type="text"
              className="form-control"
              id="descriptionForRestaurant"
              name="descriptionForRestaurant"
              placeholder="Leírás"
            />
          </div>

          <div className="row">
          <div className="col-md-6">
    <button type="submit" className="btnstyle">Létrehoz</button>
    </div>
    <div className="col-md-6">
    <button type="button" className="btnstyle">Mégse</button>
    </div>
    </div>    
        </form>
      </section>
    </>
  );
}