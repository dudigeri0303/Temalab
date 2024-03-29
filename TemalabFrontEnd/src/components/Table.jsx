import React from "react";
import { Modal } from "react-bootstrap";

export default function Table({ showModal, setShowModal, children }) {
  const handleClose = () => {
    setShowModal(false);
  };

  return (
    <>
          <Modal show={showModal} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title></Modal.Title>
        </Modal.Header>
        <Modal.Body>
        <section id="main" className="section-bg container py-3">
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
        </Modal.Body>
        <Modal.Footer>{children}</Modal.Footer>
      </Modal>
    </>
  );
}
