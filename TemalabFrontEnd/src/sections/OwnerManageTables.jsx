import "../App.css";
import React, { useEffect, useState } from "react";
import OwnerNavbar from "../components/OwnerNavbar";
import CardOwnerTables from "../components/CardOwnerTables";
import { useNavigate, useParams } from "react-router-dom";
import CheckAuth from "../common/CheckAuth";
import Table from "../components/Table";

export default function OwnerManageTables() {
  const [tables, setTables] = useState([]);
  const [showModal, setShowModal] = useState(false);
  const { id } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    document.title = " Asztalok Kezelése | DineTab";
    CheckAuth("owner", navigate);
    getTables();
  }, []);

  const getTables = async () => {
    const myHeaders = new Headers();
    const requestOptions = {
      method: "GET",
      headers: myHeaders,
      credentials: "include",
      xhrFields: { withCredentials: true },
      redirect: "follow",
    };

    try {
      const response = await fetch(
        `https://localhost:7114/api/Table/listTablesByRestaurantId?restaurantId=${id}`,
        requestOptions
      );
      const data = await response.json();
      setTables(data);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <>
      <OwnerNavbar />

      <div>
        {tables.map((table) => (
          <CardOwnerTables
            key={table.id}
            id={table.id}
            numOfSeats={table.numOfSeats}
            isReserved={table.isReserved.toString()}
          />
        ))}
      </div>

      <Table showModal={showModal} setShowModal={setShowModal}></Table>
      <div className="row">
        <div className="col-12 d-flex justify-content-center">
          <button
            className="btnstyle avgbtn my-3 py-3"
            onClick={() => setShowModal(true)}
          >
            Asztal hozzáadása
          </button>
        </div>
      </div>
    </>
  );
}
