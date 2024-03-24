import "../App.css";
import React, { useEffect, useState } from "react";
import Navbar from "../components/OwnerNavbar";
import { Modal } from "react-bootstrap";

export default function OwnerTables() {
  useEffect(() => {
    document.title = " Asztalok | DineTab";
  }, []);

  //use state for modal (true => mutat; false => nem mutat)
  const [showModal, setShowModal] = useState(false);

  //modal (popup) megnyitása
  const createTableEvent = () => {
    setShowModal(true);
  };

  //asztal mentése, modal bezárása, visszajelzés
  const saveCreateTableEvent = () => {
    setShowModal(false);
    alert("Asztal hozzáadva!");
  };

  return (
    <>
      <Navbar></Navbar>
      <label className="placeholerLabel">Még nincsenek Asztalok</label>
      <div className="col-sm d-flex justify-content-center">
        <button type="button" onClick={createTableEvent} className="cardbtn">
          ＋ Új asztal hozzáadása
        </button>
      </div>

      <Modal className="modal-bg" show={showModal} onHide={setShowModal}>
          <section id="main" className="section-bg container py-3">
            <form method="post">

              <div className="row justify-content-center">
                <div className="col-md-6">
                  <div className="mb-3">
                    <label htmlFor="numberForTable" className="label-modal">
                      Asztal férőhely
                    </label>
                    <input
                      type="number"
                      className="form-control"
                      id="numberForTable"
                      name="numberForTable"
                      placeholder="Férőhely"
                      required
                    />
                  </div>
                </div>
              </div>

            </form>

            <div className="row">
              <div className="col-md-6">
                <div className="mb-3 d-flex justify-content-center">
                  <button
                    type="button"
                    className="avgbtn"
                    onClick={saveCreateTableEvent}
                  >
                    Mentés
                  </button>
                </div>
              </div>

              <div className="col-md-6">
                <div className="mb-3 d-flex justify-content-center">
                  <button
                    type="button"
                    className="avgbtn"
                    onClick={() => {
                      setShowModal(false);
                    }}
                  >
                    Mégse
                  </button>
                </div>
              </div>
            </div>
            
          </section>
      </Modal>
    </>
  );
}
