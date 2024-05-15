import "../App.css";
import React, { useEffect, useState } from "react";
import OwnerNavbar from "../components/OwnerNavbar";
import { useParams } from 'react-router-dom';
import CardOwnerTables from "../components/CardOwnerTables";

export default function OwnerManageTables() {

    const [tables, setTables] = useState([]);

  useEffect(() => {
    document.title = " Asztalok Kezelése | DineTab";
    getTables();
  }, [tables]);

  const id = useParams();
  console.log(id)



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
        "https://localhost:7114/api/Table/listTablesByRestaurantId?restaurantId=14bc925e-bf07-4ade-9887-0af6ddc29f6d", requestOptions
      );
      const data = await response.json();
      setTables(data);
    } catch (error) {
      console.error(error);
    }
  };


  return (
    <>
    <OwnerNavbar/>

    <div>
          {tables.map((table) => (
            <CardOwnerTables key={table.id} id={table.id} numOfSeats={table.numOfSeats} isReserved={table.isReserved.toString()} />
          ))}
          </div>
    </>
  );
}
