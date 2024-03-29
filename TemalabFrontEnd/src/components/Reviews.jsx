import React from "react";
import { Modal } from "react-bootstrap";

export default function Reviews({ showModal, setShowModal, children }) {
  const handleClose = () => {
    setShowModal(false);
  };

  return (
    <Modal show={showModal} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Vélemények</Modal.Title>
      </Modal.Header>
      <Modal.Body>
      <div>
      <label>Ide jönnek a kártyák</label>
      </div>  
      </Modal.Body>
      <Modal.Footer>
      {children}
      </Modal.Footer>
    </Modal>
  );
}