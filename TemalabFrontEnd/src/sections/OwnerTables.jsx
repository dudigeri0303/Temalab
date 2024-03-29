import "../App.css";
import React, { useEffect, useState } from "react";
import Navbar from "../components/OwnerNavbar";
import Table from "../components/Table";
import { Modal } from "react-bootstrap";

export default function OwnerTables() {
  useEffect(() => {
    document.title = " Asztalok | DineTab";
  }, []);

  //use state for modal (true => mutat; false => nem mutat)

  //modal (popup) megnyitása
  const createTableEvent = () => {
    setShowModal(true);
  };

  //asztal mentése, modal bezárása, visszajelzés
  const saveCreateTableEvent = () => {
    setShowModal(false);
    alert("Asztal hozzáadva!");
  };

  const [showModal, setShowModal] = useState(false);

  return (
    <>
      <Navbar></Navbar>
      <label className="placeholerLabel">Még nincsenek Asztalok</label>
      <div className="col-sm d-flex justify-content-center">
      </div>
      <button onClick={() => setShowModal(true)} className="cardbtn">
          ＋ Új asztal hozzáadása
        </button>
      <Table showModal={showModal} setShowModal={setShowModal}>
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

      </Table>
    </>
  );
}
