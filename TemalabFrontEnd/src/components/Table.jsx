import React, { useState } from "react";
import { Modal } from "react-bootstrap";

export default function Table({ id, showModal, setShowModal, children }) {
  const [tables, setTables] = useState([]);
  const [numOfSeatsPerTable, setnumOfSeatsPerTable] = useState(0);

  const handleClose = () => {
    setShowModal(false);
  };
  //asztal mentése, modal bezárása, visszajelzés
  const saveCreateTableEvent = () => {
    postTable();
    alert("Asztal hozzáadva!");
    setShowModal(false);
  };

  const postTable = async () => {
    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        numOfSeats: numOfSeatsPerTable,
      }),
      credentials: "include",
      xhrFields: { withCredentials: true },
      redirect: "follow",
    };

    try {
      const response = await fetch(
        `https://localhost:7114/api/Table/addTableToRestaurant?restaurantId=${id}`,
        requestOptions
      );
      const data = await response.json();
      setTables(data);
    } catch (error) {
      console.error(error);
    }
  };

  const handleChange = (event) => {
    setnumOfSeatsPerTable(parseInt(event.target.value));
  };

  return (
    <>
      <Modal show={showModal} onHide={handleClose}>
        <div className="section-bg">
          <Modal.Header closeButton>
            <Modal.Title>Asztal hozzáadása</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <section id="main" className="container py-3">
              <form method="post">
                <div className="row justify-content-center">
                  <div className="col-md-6">
                    <div className="mb-3 text-center">
                      <label htmlFor="numberForTable" className="label-modal">
                        Asztal férőhely
                      </label>
                      <input
                        type="number"
                        className="form-control"
                        id="numberForTable"
                        name="numberForTable"
                        placeholder="Férőhely"
                        value={numOfSeatsPerTable}
                        onChange={handleChange}
                        required
                      />
                    </div>
                  </div>
                </div>
              </form>
            </section>
            {children}
          </Modal.Body>
          <Modal.Footer className="d-flex justify-content-center">
            <button
              type="button"
              className="avgbtn"
              onClick={saveCreateTableEvent}
            >
              Mentés
            </button>
            <button
              type="button"
              className="avgbtn"
              onClick={() => {
                setShowModal(false);
              }}
            >
              Mégse
            </button>
          </Modal.Footer>
        </div>
      </Modal>
    </>
  );
}
