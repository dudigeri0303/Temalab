import "../App.css";
import React, { useEffect, useState } from "react";
import Navbar from "../components/OwnerNavbar";
import Table from "../components/Table";

export default function OwnerTables() {
  useEffect(() => {
    document.title = " Asztalok | DineTab";
  }, []);

  //use state for modal (true => mutat; false => nem mutat)
  const [showModal, setShowModal] = useState(false);

  return (
    <>
      <Navbar></Navbar>
      <label className="placeholerLabel">Még nincsenek Asztalok</label>
      <div className="col-sm d-flex justify-content-center">
        <button onClick={() => setShowModal(true)} className="cardbtn">
          ＋ Új asztal hozzáadása
        </button>
      </div>

      <Table showModal={showModal} setShowModal={setShowModal}></Table>
    </>
  );
}
