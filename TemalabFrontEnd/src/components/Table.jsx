import React from "react";
import { Modal } from "react-bootstrap";

export default function Table({ showModal, setShowModal, children }) {
  const handleClose = () => {
    setShowModal(false);
  };

  //asztal mentése, modal bezárása, visszajelzés
  const saveCreateTableEvent = () => {
    setShowModal(false);
    alert("Asztal hozzáadva!");
  };

  return (
    <>
      <Modal show={showModal} onHide={handleClose}>
        <Modal.Header className="section-bg" closeButton>
          <Modal.Title>Asztal hozzáadása</Modal.Title>
        </Modal.Header>
        <Modal.Body className="section-bg">
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
                      required
                    />
                  </div>
                </div>
                <div className="col-md-7">
                  <div className="mb-3 text-center">
                    <label htmlFor="idForTable" className="label-modal">
                      Asztal ID
                    </label>
                    <input
                      type="text"
                      className="form-control"
                      id="idForTable"
                      name="idForTable"
                      placeholder="Asztalok megkülönböztetésére"
                      required
                    />
                  </div>
                </div>
              </div>
            </form>
          </section>
          {children}
        </Modal.Body>
        <Modal.Footer className="section-bg d-flex justify-content-center">
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
      </Modal>
    </>
  );
}
